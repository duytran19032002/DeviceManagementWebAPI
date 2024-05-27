using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using MediatR;

namespace EquipmentManagement.Application.Feature.Equipment.Queries.GetEquipment;

public class GetEquipmentHandler : IRequestHandler<GetEquipment, List<GetEquipmentDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAppLogger<GetEquipment> _logger;

	public GetEquipmentHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<GetEquipment> logger)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<List<GetEquipmentDTO>> Handle(GetEquipment request, CancellationToken cancellationToken)
	{
		//query

		var equipments = _unitOfWork.equipmentRepository.FindAll(

			 false,
			 o => o.Supplier,
			 o => o.Borrows,
			 o => o.Location, 
			 o => o.Project, 
			 o => o.EquipmentType,
			 o => o.EquipmentType.Tags
			 ).ToList();
		_logger.LogInformation("get equipment successfully");

		// convert
		if (request.Search != null)
		{
			request.Search = request.Search.ToLower();
			equipments = equipments.Where(x =>
	 (
			x.EquipmentId.ToLower().Contains(request.Search) ||
			x.EquipmentName.ToLower().Contains(request.Search) ||
			x.CodeOfManager.ToLower().Contains(request.Search) ||
			x.Location.LocationId.ToLower().Contains(request.Search) ||
			x.Supplier.SupplierName.ToLower().Contains(request.Search) ||
			(x.Project != null && x.Project.Any(x=>x.ProjectName.ToLower().Contains(request.Search))) ||
			(x.Borrows != null && x.Borrows.Any(x=>x.Borrower.ToLower().Contains(request.Search))) ||
			x.Status.ToString().ToLower().Contains(request.Search) ||
			x.EquipmentType.Category.ToString().Contains(request.Search) ||
			x.EquipmentType.Tags.Any(t => t.TagId.Contains(request.Search))
	 )
	).ToList();
		}

		var data = new List<GetEquipmentDTO>();
		foreach (var equipment in equipments)
		{
			var dt = new GetEquipmentDTO()
			{
				EquipmentId = equipment.EquipmentId,
				Status = equipment.Status,
				CodeOfManager = equipment.CodeOfManager,
				EquipmentName = equipment.EquipmentName,
				EquipmentTypeId = equipment.EquipmentTypeId,
				LocationId = equipment.Location.LocationId,
				SupplierName= equipment.Supplier.SupplierName,
				YearOfSupply = equipment.YearOfSupply,
				Tags = equipment.EquipmentType.Tags.Select(x=>x.TagId).ToList(),
			};
			data.Add(dt);

		}


		return data;

	}
}
