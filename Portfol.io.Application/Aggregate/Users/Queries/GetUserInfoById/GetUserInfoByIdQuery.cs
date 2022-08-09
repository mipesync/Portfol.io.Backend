using MediatR;

namespace Portfol.io.Application.Aggregate.Users.Queries.GetUserInfoById
{
    public class GetUserInfoByIdQuery : IRequest<UserDetailsViewModel>
    {
        public Guid UserId { get; set; }
    }
}
