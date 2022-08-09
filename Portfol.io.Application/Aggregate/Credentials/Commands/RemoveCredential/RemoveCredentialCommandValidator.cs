using FluentValidation;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.RemoveCredential
{
    public class RemoveCredentialCommandValidator : AbstractValidator<RemoveCredentialCommand>
    {
        public RemoveCredentialCommandValidator()
        {
            RuleFor(removeCredentialCommand => removeCredentialCommand.Model)
                .NotEmpty().WithMessage("Model is required.");

            RuleFor(removeCredentialCommand => removeCredentialCommand.Model.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(5).WithMessage("The username lenght must not be less than 5.");

            RuleFor(removeCredentialCommand => removeCredentialCommand.Model.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("The password lenght must not be less than 8.");

            RuleFor(updateCredentialCommand => updateCredentialCommand.Model.VerifyCode)
                .NotEmpty().WithMessage("Verify code is required.")
                .Length(6).WithMessage("The verify code lenght should be 6.");
        }
    }
}
