using MediatR;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential.ResetPassword
{
    public class ResetPasswordCommand : IRequest<Unit>
    {
        public ResetPasswordViewModel Model { get; set; } = null!;
    }
}
