using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;

namespace EquipmentManagement.Application.Feature.Project.Commands.EndProject;

public class EndPrjHandler : IRequestHandler<EndPrj, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAppLogger<EndPrj> _logger;

	public EndPrjHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<EndPrj> logger)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}
	public async Task<string> Handle(EndPrj request, CancellationToken cancellationToken)
	{
		//validate
		var checkPrj = _unitOfWork.projectRepository.FindByCondition(x => x.ProjectName == request.ProjectName, trackChanges: true, x=>x.Borrows).FirstOrDefault();
		if (checkPrj.Borrows.Any(x=>x.RealReturnedDate==null))
		{
			throw new BadRequestException("Invalid Project, need to finish borrrow");
		}
		if (checkPrj.RealEndDate != null)
		{
			throw new BadRequestException("Invalid Project,prj ended");
		}


		//var equips = _unitOfWork.projectRepository.FindByCondition(
		//	x => x.ProjectName==request.ProjectName, trackChanges: true, x=>x.Equipments).SelectMany(x=>x.Equipments).ToList();
		
		//foreach(var e in equips)
		//{
		//	e.Project = null;
		//	_unitOfWork.equipmentRepository.Update(e);
		//}

		var prjToEnd = await _unitOfWork.projectRepository.GetByIdAsync(request.ProjectName);
		prjToEnd.RealEndDate=request.RealEndDate;
		_unitOfWork.projectRepository.Update(prjToEnd);

		await _unitOfWork.SaveChangeAsync();
		//return 
		return request.ProjectName;
	}
}

