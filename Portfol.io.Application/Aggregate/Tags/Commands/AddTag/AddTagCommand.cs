using MediatR;

namespace Portfol.io.Application.Aggregate.Tags.Commands.AddTag
{
    public class AddTagCommand :  IRequest<Guid>
    {
        public string Name { get; set; } = null!;
    }
}
