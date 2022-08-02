using MediatR;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Credentials.Queries
{
    public class GetCredentialByUsernameQuery : IRequest<CredentialUsernameVm>
    {
        public string Username { get; set; } = null!;
    }
}
