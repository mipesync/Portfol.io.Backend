using AutoMapper;
using Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbum;
using Portfol.io.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace Portfol.io.WebAPI.Models
{
    public class UpdateAlbumDto : IMapWith<UpdateAlbumCommand>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAlbumDto, UpdateAlbumCommand>()
                .ForMember(command => command.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(command => command.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(command => command.Description, opt => opt.MapFrom(dto => dto.Description));
        }
    }
}
