using MediatR;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Tags.Queries.GetTags
{
    public class GetTagsQuery : IRequest<List<Tag>> { }
}
