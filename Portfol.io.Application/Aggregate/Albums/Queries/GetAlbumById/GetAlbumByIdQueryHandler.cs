using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumById
{
    public class GetAlbumByIdQueryHandler : IRequestHandler<GetAlbumByIdQuery, GetAlbumLookupDto>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public GetAlbumByIdQueryHandler(IPortfolioDbContext dbContext, IMapper mapper, IConfiguration config)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _config = config;
        }

        public async Task<GetAlbumLookupDto> Handle(GetAlbumByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Albums
                .Include(u => u.Photos)
                .Include(u => u.Tags)
                .Include(u => u.AlbumLikes)
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            entity!.Views++;

            if (entity is null || entity.Id != request.Id)
                throw new NotFoundException(nameof(Album), request.Id);

            var dto = _mapper.Map<GetAlbumLookupDto>(entity);
            if (entity.AlbumLikes!.Any(u => u.UserId == request.UserId))
                dto.IsLiked = true;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return dto;
        }
    }
}
