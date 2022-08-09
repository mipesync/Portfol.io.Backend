using AutoMapper;
using Portfol.io.Application.Common.Mappings;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Users.Queries.GetUserById
{
    public class UserViewModel : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ProfileImagePath { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Email { get; set; }
        public ICollection<AlbumLookupDto>? Albums { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserViewModel>()
                .ForMember(userVm => userVm.Id, opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.Name, opt => opt.MapFrom(user => user.Name))
                .ForMember(userVm => userVm.Description, opt => opt.MapFrom(user => user.Description))
                .ForMember(userVm => userVm.ProfileImagePath, opt => opt.MapFrom(user => user.ProfileImagePath))
                .ForMember(userVm => userVm.DateOfBirth, opt => opt.MapFrom(user => user.DateOfBirth))
                .ForMember(userVm => userVm.Email, opt => opt.MapFrom(user => user.Email))
                .ForMember(userVm => userVm.Albums, opt => opt.MapFrom(user => user.UserAlbums));
        }
    }
}