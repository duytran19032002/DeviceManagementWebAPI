using AutoMapper;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using EquipmentManagement.Application.Feature.EquipmentType.Commands.UpdateET;
using EquipmentManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Form.Commands.CheckForm;
public class CheckedFormHandler : IRequestHandler<CheckedForm, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;

	public CheckedFormHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(CheckedForm request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new CheckedFormValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid Form", validatorResult);
		}
		//convert
		var forms = _unitOfWork.googleFormRepository.FindByCondition(x => x.ProjectName == request.ProjectName, trackChanges: true).ToList();
		if (forms == null)
		{
			throw new BadRequestException("Notfound");
		}
		else
		{
			foreach(var form in forms)
			{
				form.CheckSeen = true;
				_unitOfWork.googleFormRepository.Update(form);
			};
		}
		//add to db

		await _unitOfWork.SaveChangeAsync();
		//return 
		return request.ProjectName;
	}
}
