using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;
using System.Text.RegularExpressions;

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

            if (album is null || album.Id != request.AlbumId)
                throw new NotFoundException(nameof(Album), request.AlbumId);

            if (album.UserId == request.UserId) throw new Exception("Вы не можете оценивать свой альбом");

            var entity = new AlbumLike
            {
                AlbumId = request.AlbumId,
                UserId = request.UserId
            };

            await _dbContext.AlbumLikes.AddAsync(entity, cancellationToken);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException e)
            {
                if (Regex.IsMatch(e.InnerException!.Message, @"\w*23505"))
                {
                    _dbContext.AlbumLikes.Attach(entity);
                    _dbContext.AlbumLikes.Remove(entity);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }
            }

            return Unit.Value;
        }
    }
}
