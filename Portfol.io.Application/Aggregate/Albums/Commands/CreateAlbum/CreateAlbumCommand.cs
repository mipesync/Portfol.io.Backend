﻿using MediatR;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid UserId { get; set; }

        //TODO: Переделать. Сделать dto с полем Name, смапить в Tag
        public List<Tag>? Tags { get; set; }
    }
}
