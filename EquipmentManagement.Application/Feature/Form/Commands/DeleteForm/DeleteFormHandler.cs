using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using EquipmentManagement.Domain;
using MediatR;

namespace EquipmentManagement.Application.Feature.Form.Commands.DeleteForm;

public class DeleteFormHandler : IRequestHandler<DeleteForm, string>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteFormHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(DeleteForm request, CancellationToken cancellationToken)
	{


		var formDelete =  _unitOfWork.googleFormRepository.FindByCondition(x=>x.ProjectName==request.ProjectName).ToList();
		if (formDelete == null)
		{
			throw new NotFoundException(nameof(GoogleForm), request.ProjectName);
		}

		_unitOfWork.googleFormRepository.RemoveRange(formDelete);
		await _unitOfWork.SaveChangeAsync();
		return request.ProjectName;
	}
}
