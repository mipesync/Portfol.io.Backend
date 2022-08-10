using MediatR;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;

        public CreateAlbumCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var entity = new Album
            {
                Name = request.Model.Name,
                Description = request.Model.Description,
                CreationDate = DateTime.UtcNow,
                UserId = request.Model.UserId,
                //TODO: Добавить команды для Tag
                Tags = request.Model.Tags
            };

            await _dbContext.Albums.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
