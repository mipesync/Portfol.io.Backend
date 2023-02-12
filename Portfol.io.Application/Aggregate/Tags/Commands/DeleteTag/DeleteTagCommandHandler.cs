using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Tags.Commands.DeleteTag
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;

        public DeleteTagCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tags.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (entity is null || entity.Id != request.Id)
                throw new NotFoundException(nameof(Tag), request.Id);

            _dbContext.Tags.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
