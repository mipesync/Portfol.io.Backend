﻿using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumById
{
    public class GetAlbumByIdQuery : IRequest<AlbumViewModel>
    {
        public Guid Id { get; set; }
    }
}
