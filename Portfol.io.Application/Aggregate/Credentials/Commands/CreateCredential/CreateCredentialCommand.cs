using MediatR;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.CreateCredential
{
    public class CreateCredentialCommand : IRequest<string>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
