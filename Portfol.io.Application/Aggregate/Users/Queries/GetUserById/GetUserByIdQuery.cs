using MediatR;

namespace Portfol.io.Application.Aggregate.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public Guid Id { get; set; }
    }
}
