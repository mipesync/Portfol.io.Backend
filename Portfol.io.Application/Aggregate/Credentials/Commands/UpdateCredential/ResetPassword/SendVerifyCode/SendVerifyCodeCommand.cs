using MediatR;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential.ResetPassword.SendVerifyCode
{
    public class SendVerifyCodeCommand : IRequest<string>
    {
        public string Email { get; set; } = null!;
    }
}
