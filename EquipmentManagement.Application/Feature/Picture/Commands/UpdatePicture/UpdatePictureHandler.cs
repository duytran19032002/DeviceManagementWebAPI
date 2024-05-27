using AutoMapper;
using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;

namespace EquipmentManagement.Application.Feature.Picture.Commands.UpdatePicture;

public class UpdatePictureHandler : IRequestHandler<UpdatePicture, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _picture;
	private readonly IPictureRepository _pictureRepository;

	public UpdatePictureHandler(IMapper mapper, IUnitOfWork picture, IPictureRepository pictureRepository)
	{
		_mapper = mapper;
		_picture = picture;
		_pictureRepository = pictureRepository;
	}
	public async Task<string> Handle(UpdatePicture request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new UpdatePictureValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid picture", validatorResult);
		}
		//convert
		var picToDel = _pictureRepository.FindByCondition(x=>x.EquipmentTypeId==request.EquipmentTypeId, trackChanges: true).ToList();
		_pictureRepository.RemoveRange(picToDel);

		var P = new List<Domain.Picture>();
		if (request.FileData != null)
		{
			foreach (var pic in request.FileData)
			{
				var pictureToCreate = new Domain.Picture
				{
					EquipmentTypeId = request.EquipmentTypeId,
					FileData = Convert.FromBase64String(pic),
				};
				P.Add(pictureToCreate);
			}
		}
		_picture.pictureRepository.AddRange(P);



		//add to db

		await _picture.SaveChangeAsync();
		//return 
		return request.EquipmentTypeId;
	}
}

