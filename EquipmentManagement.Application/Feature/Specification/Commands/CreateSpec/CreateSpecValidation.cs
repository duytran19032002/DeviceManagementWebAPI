using FluentValidation;

namespace EquipmentManagement.Application.Feature.Specification.Commands.CreateSpec;

public class CreateSpecValidation : AbstractValidator<CreateSpec>
{
	public CreateSpecValidation()
	{
		RuleFor(p => p.EquipmentTypeId)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);

	}

}
