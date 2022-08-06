using MediatR;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential
{
    public class UpdateCredentialCommand : IRequest<Unit>
    {
        public string Username { get; set; } = null!;
    }
}
