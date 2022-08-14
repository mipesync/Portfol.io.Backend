using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Commands.DeleteImage
{
    public class DeleteImageCommandHanlder : IRequestHandler<DeleteImageCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;

        public DeleteImageCommandHanlder(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Photos
                .FirstOrDefaultAsync(u => u.AlbumId == request.AlbumId && u.Id == request.PhotoId, cancellationToken);

            if (entity is null || entity.Id != request.AlbumId)
                throw new NotFoundException(nameof(Photo), new[] { request.AlbumId, request.PhotoId });

            File.Delete($"{request.WebRootPath}{entity.Path}");

            _dbContext.Photos.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
