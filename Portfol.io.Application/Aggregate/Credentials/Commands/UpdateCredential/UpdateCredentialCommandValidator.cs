using FluentValidation;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential
{
    public class UpdateCredentialCommandValidator : AbstractValidator<UpdateCredentialCommand>
    {
        public UpdateCredentialCommandValidator()
        {
            RuleFor(updateCredentialCommand => updateCredentialCommand.Model)
                .NotEmpty().WithMessage("Model is required.");

            RuleFor(updateCredentialCommand => updateCredentialCommand.Model.OldUsername)
                .NotEmpty().WithMessage("Old username is required.")
                .MinimumLength(5).WithMessage("The old username lenght must not be less than 5.");

            RuleFor(updateCredentialCommand => updateCredentialCommand.Model.NewUsername)
                .NotEmpty().WithMessage("New username is required.")
                .MinimumLength(5).WithMessage("The new username lenght must not be less than 5.");

            RuleFor(updateCredentialCommand => updateCredentialCommand.Model.VerifyCode)
                .NotEmpty().WithMessage("Verify code is required.")
                .Length(6).WithMessage("The verify code lenght should be 6.");
        }
    }
}
