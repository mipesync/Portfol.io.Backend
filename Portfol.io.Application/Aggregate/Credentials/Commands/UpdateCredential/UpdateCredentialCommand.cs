using MediatR;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential
{
    public class UpdateCredentialCommand : IRequest<Unit>
    {
        public string OldUsername { get; set; } = null!;
        public string NewUsername { get; set; } = null!;
        public string VerifyCode { get; set; } = null!;
    }
}
