using AutoMapper;
using Portfol.io.Application.Aggregate.Albums.Commands.CreateAlbum;
using Portfol.io.Application.Common.Mappings;
using Portfol.io.Domain;
using System.ComponentModel.DataAnnotations;

namespace Portfol.io.Application
{
    public class CreateAlbumDto : IMapWith<CreateAlbumCommand>
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string? Description { get; set; }
        public List<Tag>? Tags { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAlbumDto, CreateAlbumCommand>()
                .ForMember(command => command.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(command => command.Description, opt => opt.MapFrom(dto => dto.Description))
                .ForMember(command => command.Tags, opt => opt.MapFrom(dto => dto.Tags));
        }
    }
}
