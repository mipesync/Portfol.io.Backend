using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Photos.Commands.DeleteImage
{
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;

        public DeleteImageCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Photos
                .FirstOrDefaultAsync(u => u.AlbumId == request.AlbumId && u.Id == request.ImageId, cancellationToken);

            if (entity is null || entity.Id != request.ImageId || entity.AlbumId != request.AlbumId)
                throw new NotFoundException(nameof(Photo), request.ImageId);

            File.Delete($"{(request.WebRootPath is null
                ? throw new ArgumentException("WebRootPath не может быть пустым")
                : request.WebRootPath)}{entity.Path}");

            _dbContext.Photos.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
