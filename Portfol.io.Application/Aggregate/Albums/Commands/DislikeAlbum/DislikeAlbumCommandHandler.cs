using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Commands.DislikeAlbum
{
    public class DislikeAlbumCommandHandler : IRequestHandler<DislikeAlbumCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;

        public DislikeAlbumCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DislikeAlbumCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.AlbumLikes.Where(u => u.AlbumId == request.Id).FirstOrDefaultAsync(u => u.UserId == request.UserId);

            if (entity is null || entity.AlbumId != request.Id || entity.UserId != request.UserId)
                throw new NotFoundException(nameof(AlbumLike), new { request.Id, request.UserId });

            _dbContext.AlbumLikes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
