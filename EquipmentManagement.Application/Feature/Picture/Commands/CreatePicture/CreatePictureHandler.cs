using AutoMapper;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Picture.Commands.CreatePicture;
public class CreatePictureHandler : IRequestHandler<CreatePicture, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _picture;

	public CreatePictureHandler(IMapper mapper, IUnitOfWork picture)
	{
		_mapper = mapper;
		_picture = picture;
	}
	public async Task<string> Handle(CreatePicture request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new CreatePictureValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid picture", validatorResult);
		}
		//convert

		if (request.FileData != null)
		{
			foreach (var pic in request.FileData)
			{
				var pictureToCreate = new Domain.Picture
				{
					EquipmentTypeId = request.EquipmentTypeId,
					FileData = Convert.FromBase64String(pic),
				};
				_picture.pictureRepository.Add(pictureToCreate);
			}
		}




		//add to db

		await _picture.SaveChangeAsync();
		//return 
		return request.EquipmentTypeId;
	}
}


