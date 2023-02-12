using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Commands.RemoveAlbum
{
    public class RemoveAlbumCommandHandler : IRequestHandler<RemoveAlbumCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;

        public RemoveAlbumCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(RemoveAlbumCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Albums.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (entity is null || entity.Id != request.Id)
                throw new NotFoundException(nameof(Album), request.Id);

            _dbContext.Albums.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
