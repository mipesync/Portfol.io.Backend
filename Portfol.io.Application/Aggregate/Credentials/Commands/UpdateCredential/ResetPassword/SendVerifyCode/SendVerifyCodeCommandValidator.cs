using FluentValidation;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential.ResetPassword.SendVerifyCode
{
    public class SendVerifyCodeCommandValidator : AbstractValidator<SendVerifyCodeCommand>
    {
        public SendVerifyCodeCommandValidator()
        {
            RuleFor(sendVerifyCodeCommand => sendVerifyCodeCommand.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Doesn't match the email format.");
        }
    }
}
