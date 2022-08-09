using MediatR;

namespace Portfol.io.Application.Aggregate.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public CreateUserViewModel Model { get; set; } = null!;
    }
}
