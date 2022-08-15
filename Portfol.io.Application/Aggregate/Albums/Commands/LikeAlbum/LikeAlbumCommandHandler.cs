using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Commands.LikeAlbum
{
    public class LikeAlbumCommandHandler : IRequestHandler<LikeAlbumCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;

        public LikeAlbumCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(LikeAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = await _dbContext.Albums.FirstOrDefaultAsync(u => u.Id == request.AlbumId, cancellationToken);

            if (album is null || album.Id != request.AlbumId) throw new NotFoundException(nameof(Album), request.AlbumId);

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user is null || user.Id != request.UserId) throw new NotFoundException(nameof(User), request.UserId);

            var entity = new AlbumLike
            {
                AlbumId = request.AlbumId,
                UserId = request.UserId
            };

            await _dbContext.AlbumLikes.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
