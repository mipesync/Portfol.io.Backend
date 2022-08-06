using MediatR;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential.ResetPassword
{
    public class ResetPasswordCommand : IRequest<Unit>
    {
        public string Username { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string ConfirmNewPassword { get; set; } = null!;
        public string VerifyCode { get; set; } = null!;
        public string SentVerifyCode { get; set; } = null!;
    }
}
