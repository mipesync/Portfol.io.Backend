using MediatR;

namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public UpdateUserViewModel Model { get; set; } = null!;
    }
}
