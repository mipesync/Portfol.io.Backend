using FluentValidation;

namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUserImage
{
    public class UpdateUserImageCommandValidator : AbstractValidator<UpdateUserImageCommand>
    {
        public UpdateUserImageCommandValidator()
        {
            RuleFor(updateUserImageCommand => updateUserImageCommand.ImageFile)
                .NotEmpty().WithMessage("ImageFile is required.");

            RuleFor(updateUserImageCommand => updateUserImageCommand.WebRootPath)
                .NotEmpty().WithMessage("WebRootPath is required.");

            RuleFor(updateUserImageCommand => updateUserImageCommand.HostUrl)
                .NotEmpty().WithMessage("HostUrl is required.");

            RuleFor(updateUserImageCommand => updateUserImageCommand.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required");
        }
    }
}
