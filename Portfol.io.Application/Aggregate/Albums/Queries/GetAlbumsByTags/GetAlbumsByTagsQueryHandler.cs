using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByTags
{
    public class GetAlbumsByTagsQueryHandler : IRequestHandler<GetAlbumsByTagsQuery, AlbumsViewModel>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAlbumsByTagsQueryHandler(IPortfolioDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AlbumsViewModel> Handle(GetAlbumsByTagsQuery request, CancellationToken cancellationToken)
        {
            var entities = new List<AlbumTag>();

            foreach(var tagId in request.TagIds)
            {
                entities.AddRange(await _dbContext.AlbumTags.Include(u => u.Album).Where(u => u.TagId == tagId).ToListAsync());
            }

            if (entities.Count() == 0) throw new NotFoundException(nameof(Album), request.TagIds);

            var albumLookupDto = new List<AlbumLookupDto>();

            foreach (var album in entities)
            {
                albumLookupDto.Add(_mapper.Map<AlbumLookupDto>(album.Album));
            }

            return new AlbumsViewModel { Albums = albumLookupDto };
        }
    }
}
