using MediatR;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.RemoveCredential
{
    public class RemoveCredentialCommand : IRequest<Unit>
    {
        public RemoveCredentialViewModel Model { get; set; } = null!;
    }
}
