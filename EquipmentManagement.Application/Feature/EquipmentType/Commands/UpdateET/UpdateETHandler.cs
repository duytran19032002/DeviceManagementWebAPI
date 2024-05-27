using AutoMapper;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;

namespace EquipmentManagement.Application.Feature.EquipmentType.Commands.UpdateET;

public class UpdateETHandler : IRequestHandler<UpdateET, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateETHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(UpdateET request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new UpdateETValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid ET", validatorResult);
		}
		//convert
		var a = _unitOfWork.equipmentTypeRepository.FindByCondition(x =>x.EquipmentTypeId== request.EquipmentTypeId, trackChanges: true, x => x.Tags).ToList().FirstOrDefault();
		if ( a==null)
        {
			throw new BadRequestException("Notfound");
		}
		else
		{
			a.Description = request.Description;
			a.Category = request.Category;
			a.EquipmentTypeName = request.EquipmentTypeName;
			if(request.Tags!=null)
			{
				a.Tags = _unitOfWork.tagRepository.FindByCondition(x => request.Tags.Any(id => x.TagId == id),trackChanges:true).ToList();
			}
		}
		//add to db
		_unitOfWork.equipmentTypeRepository.Update(a);

		//convert
		if (request.Pictures !=null)
		{
			var pictureToDelete = _unitOfWork.pictureRepository.FindByCondition(x => x.EquipmentTypeId == a.EquipmentTypeId).ToList();
			_unitOfWork.pictureRepository.RemoveRange(pictureToDelete);

			var pictureToCreate = new List<Domain.Picture>();

			foreach (var picture in request.Pictures)
			{
				if (!string.IsNullOrEmpty(picture.FileData))
				{
					var b = new Domain.Picture
					{
						FileData = Convert.FromBase64String(picture.FileData),
						EquipmentTypeId = request.EquipmentTypeId,
					};
					pictureToCreate.Add(b);

				}
			}
			_unitOfWork.pictureRepository.AddRange(pictureToCreate);
		}


		if (request.Specification != null)
		{
			var specToDelete = _unitOfWork.specificationRepository.FindByCondition(x => x.EquipmentTypeId == a.EquipmentTypeId).ToList();
			_unitOfWork.specificationRepository.RemoveRange(specToDelete);

			var specToCreate = new List<Domain.Specification>();

				foreach (var item in request.Specification)
				{
					var c = new Domain.Specification
					{
						Name = item.Name,
						Value = item.Value,
						Unit = item.Unit,
						EquipmentTypeId = request.EquipmentTypeId
					};
					specToCreate.Add(c);
				}

			_unitOfWork.specificationRepository.AddRange(specToCreate);
		}





		await _unitOfWork.SaveChangeAsync();
        //return 
        return a.EquipmentTypeId;
	}
}
