using MediatR;

namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUserImage
{
    public class UpdateUserImageCommand : IRequest<Unit>
    {
        public UpdateUserImageViewModel Model { get; set; } = null!;
    }
}
