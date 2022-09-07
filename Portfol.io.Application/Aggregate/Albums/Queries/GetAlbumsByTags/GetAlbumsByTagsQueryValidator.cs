using FluentValidation;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByTags
{
    public class GetAlbumsByTagsQueryValidator : AbstractValidator<GetAlbumsByTagsQuery>
    {
        public GetAlbumsByTagsQueryValidator()
        {
            RuleFor(getAlbumsByTagsQueryValidator => getAlbumsByTagsQueryValidator.TagIds)
                .NotEqual(default(IEnumerable<Guid>));
        }
    }
}
