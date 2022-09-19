using MediatR;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Tags.Commands.AddTag
{
    public class AddTagCommandHandler : IRequestHandler<AddTagCommand, Guid>
    {
        private readonly IPortfolioDbContext _dbContext;

        public AddTagCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(AddTagCommand request, CancellationToken cancellationToken)
        {
            var entity = new Tag
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _dbContext.Tags.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
