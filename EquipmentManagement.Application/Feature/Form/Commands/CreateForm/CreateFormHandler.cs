using AutoMapper;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;

namespace EquipmentManagement.Application.Feature.Form.Commands.CreateForm;

public class CreateFormHandler : IRequestHandler<CreateForm, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;

	public CreateFormHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(CreateForm request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new CreatFormValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid Form", validatorResult);
		}
		//convert
		var form = _mapper.Map<Domain.GoogleForm>(request);

		//add to db
		_unitOfWork.googleFormRepository.Add(form);
		await _unitOfWork.SaveChangeAsync();
		//return 
		return form.ProjectName;
	}
}
