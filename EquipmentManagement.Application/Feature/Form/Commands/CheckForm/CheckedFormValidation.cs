using FluentValidation;

namespace EquipmentManagement.Application.Feature.Form.Commands.CheckForm;

public class CheckedFormValidation : AbstractValidator<CheckedForm>
{
	public CheckedFormValidation()
	{
		RuleFor(p => p.ProjectName)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);

	}

}
