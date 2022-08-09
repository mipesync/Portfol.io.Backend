using MediatR;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.CreateCredential
{
    public class CreateCredentialCommand : IRequest<string>
    {
        public CreateCredentialViewModel Model { get; set; } = null!;
    }
}
