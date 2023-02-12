using AutoMapper;
using Portfol.io.Application.Common.Mappings;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Photos.DTO
{
    public class GetImageByIdDto : IMapWith<Photo>
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Photo, GetImageByIdDto>()
                .ForMember(u => u.Id, opt => opt.MapFrom(u => u.Id))
                .ForMember(u => u.Path, opt => opt.MapFrom(u => u.Path));
        }
    }
}