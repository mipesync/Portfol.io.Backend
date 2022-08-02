using MediatR;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential
{
    public class UpdateCredentialCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
    }
}
