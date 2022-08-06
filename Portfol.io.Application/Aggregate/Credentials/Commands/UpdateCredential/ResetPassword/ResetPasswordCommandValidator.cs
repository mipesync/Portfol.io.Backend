using FluentValidation;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential.ResetPassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(resetPasswordCommand => resetPasswordCommand.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(5).WithMessage("The username lenght must not be less than 5.");

            RuleFor(resetPasswordCommand => resetPasswordCommand.NewPassword)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("The password lenght must not be less than 8.");

            RuleFor(resetPasswordCommand => resetPasswordCommand.ConfirmNewPassword)
                .NotEmpty().WithMessage("Confirmation password is required.")
                .MinimumLength(8).WithMessage("The confirmation password lenght must not be less than 8.");

            RuleFor(resetPasswordCommand => resetPasswordCommand.VerifyCode)
                .NotEmpty().WithMessage("Verify code is required.")
                .Length(6).WithMessage("The verify code lenght should be 6.");

            RuleFor(resetPasswordCommand => resetPasswordCommand.SentVerifyCode)
                .NotEmpty().WithMessage("Confirmation verify code is required.")
                .Length(6).WithMessage("The confirmation verify code lenght should be 6.");
        }
    }
}
