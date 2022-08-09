using MediatR;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential
{
    public class UpdateCredentialCommand : IRequest<Unit>
    {
        public UpdateCredentialViewModel Model { get; set; } = null!;
    }
}
