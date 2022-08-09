using FluentValidation;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.CreateCredential
{
    public class CreateCredentialCommandValidator : AbstractValidator<CreateCredentialCommand>
    {
        public CreateCredentialCommandValidator()
        {
            RuleFor(createCredentialCommand => createCredentialCommand.Model)
                .NotEmpty().WithMessage("Model is required.");

            RuleFor(createCredentialCommand => createCredentialCommand.Model.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(5).WithMessage("The username lenght must not be less than 5.");

            RuleFor(createCredentialCommand => createCredentialCommand.Model.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("The password lenght must not be less than 8.");

            RuleFor(createCredentialCommand => createCredentialCommand.Model.ConfirmPassword)
                .NotEmpty().WithMessage("Confirmation password is required.")
                .MinimumLength(8).WithMessage("The confirmation password lenght must not be less than 8.");
        }
    }
}
