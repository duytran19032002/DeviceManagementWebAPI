using FluentValidation;

namespace EquipmentManagement.Application.Feature.Picture.Commands.UpdatePicture;

public class UpdatePictureValidation : AbstractValidator<UpdatePicture>
{
	public UpdatePictureValidation()
	{
		RuleFor(p => p.EquipmentTypeId)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);

		RuleFor(p => p.FileData)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull();
	}

}