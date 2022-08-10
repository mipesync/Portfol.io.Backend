using MediatR;

namespace Portfol.io.Application.Aggregate.Credentials.Queries.GetCredentialByUsername
{
    //TODO: создать VM или Dto и передать в конструктор
    public class GetCredentialByUsernameQuery : IRequest<CredentialUsernameViewModel>
    {
        public string Username { get; set; } = null!;
    }
}
