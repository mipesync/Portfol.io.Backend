using MediatR;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, Guid>
    {
        private readonly IPortfolioDbContext _dbContext;

        public CreateAlbumCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var entity = new Album
            {
                Name = request.Name,
                Description = request.Description,
                CreationDate = DateTime.UtcNow,
                UserId = request.UserId,
                Tags = request.Tags!
            };

            _dbContext.Tags.AttachRange(request.Tags!);
            await _dbContext.Albums.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
