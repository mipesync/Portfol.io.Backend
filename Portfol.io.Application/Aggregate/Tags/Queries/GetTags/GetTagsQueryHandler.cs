using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Tags.Queries.GetTags
{
    public class GetTagsQueryHandler : IRequestHandler<GetTagsQuery, List<Tag>>
    {
        private readonly IPortfolioDbContext _dbContext;

        public GetTagsQueryHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Tag>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dbContext.Tags
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            if (entities.Count() == 0)
                throw new NotFoundException(nameof(Tag), null!);

            return entities;
        }
    }
}
