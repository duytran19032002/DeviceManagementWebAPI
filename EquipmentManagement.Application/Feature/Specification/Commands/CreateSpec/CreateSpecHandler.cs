using AutoMapper;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;

namespace EquipmentManagement.Application.Feature.Specification.Commands.CreateSpec;

public class CreateSpecHandler : IRequestHandler<CreateSpec, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _specRepository;

	public CreateSpecHandler(IMapper mapper, IUnitOfWork specRepository)
	{
		_mapper = mapper;
		_specRepository = specRepository;
	}
	public async Task<string> Handle(CreateSpec request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new CreateSpecValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid spec", validatorResult);
		}
		//convert
		//var specToCreate = _mapper.Map<Domain.Specification>(request
		foreach (var sp in request.Specs)
		{
			if (sp != null)
			{
				var a = new Domain.Specification
				{
					EquipmentTypeId = request.EquipmentTypeId,
					Name = sp.Name,
					Value = sp.Value,
					Unit = sp.Unit,
				};
				_specRepository.specificationRepository.Add(a);
			}
		}

		//add to db

		await _specRepository.SaveChangeAsync();
		//return 
		return request.EquipmentTypeId;
	}
}
