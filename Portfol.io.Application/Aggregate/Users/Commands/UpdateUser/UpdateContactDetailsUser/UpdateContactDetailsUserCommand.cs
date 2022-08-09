using MediatR;

namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUser.UpdateContactDetailsUser
{
    public class UpdateContactDetailsUserCommand : IRequest<Unit>
    {
        public UpdateContactDetailsUserViewModel Model { get; set; } = null!;
    }
}
