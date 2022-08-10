using MediatR;
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
            var entity = new AlbumLike
            {
                AlbumId = request.Id,
                UserId = request.UserId
            };

            await _dbContext.AlbumLikes.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
