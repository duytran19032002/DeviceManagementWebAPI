using FluentValidation;

namespace EquipmentManagement.Application.Feature.Form.Commands.CreateForm;

public class CreatFormValidation : AbstractValidator<CreateForm>
{
	public CreatFormValidation()
	{
		RuleFor(p => p.ProjectName)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(500);
		RuleFor(p => p.Email)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(500);

	}

}
