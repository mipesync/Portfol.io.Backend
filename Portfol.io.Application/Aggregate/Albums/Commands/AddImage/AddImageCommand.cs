using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.AddImage
{
    public class AddImageCommand : IRequest<Unit>
    {
        public AddImageViewModel Model { get; set; } = null!;
    }
}
