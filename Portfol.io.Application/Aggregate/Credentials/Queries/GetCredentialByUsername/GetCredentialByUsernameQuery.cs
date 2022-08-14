using MediatR;

namespace Portfol.io.Application.Aggregate.Credentials.Queries.GetCredentialByUsername
{
    public class GetCredentialByUsernameQuery : IRequest<CredentialUsernameViewModel>
    {
        public string Username { get; set; } = null!;
    }
}
