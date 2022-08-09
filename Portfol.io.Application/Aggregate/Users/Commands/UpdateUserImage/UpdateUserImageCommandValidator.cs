using FluentValidation;

namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUserImage
{
    public class UpdateUserImageCommandValidator : AbstractValidator<UpdateUserImageCommand>
    {
        public UpdateUserImageCommandValidator()
        {
            RuleFor(updateUserImageCommand => updateUserImageCommand.Model)
                .NotEmpty().WithMessage("Model is required.");

            RuleFor(updateUserImageCommand => updateUserImageCommand.Model.ImageFile)
                .NotEmpty().WithMessage("ImageFile is required.");

            RuleFor(updateUserImageCommand => updateUserImageCommand.Model.WebRootPath)
                .NotEmpty().WithMessage("WebRootPath is required.");

            RuleFor(updateUserImageCommand => updateUserImageCommand.Model.HostUrl)
                .NotEmpty().WithMessage("HostUrl is required.");

            RuleFor(updateUserImageCommand => updateUserImageCommand.Model.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required");
        }
    }
}
