using FluentValidation;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential.ResetPassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(updateCredentialCommand => updateCredentialCommand.Model)
                .NotEmpty().WithMessage("Model is required.");

            RuleFor(resetPasswordCommand => resetPasswordCommand.Model.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(5).WithMessage("The username lenght must not be less than 5.");

            RuleFor(resetPasswordCommand => resetPasswordCommand.Model.NewPassword)
                .NotEmpty().WithMessage("New password is required.")
                .MinimumLength(8).WithMessage("The password lenght must not be less than 8.");

            RuleFor(resetPasswordCommand => resetPasswordCommand.Model.ConfirmNewPassword)
                .NotEmpty().WithMessage("Confirmation new password is required.")
                .MinimumLength(8).WithMessage("The confirmation password lenght must not be less than 8.");

            RuleFor(resetPasswordCommand => resetPasswordCommand.Model.VerifyCode)
                .NotEmpty().WithMessage("Verify code is required.")
                .Length(6).WithMessage("The verify code lenght should be 6.");
        }
    }
}
