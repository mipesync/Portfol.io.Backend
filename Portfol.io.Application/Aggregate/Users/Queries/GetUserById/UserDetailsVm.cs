using AutoMapper;
using Portfol.io.Application.Common.Mappings;
using Portfol.io.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfol.io.Application.Aggregate.Users.Queries.GetUserById
{
    public class UserDetailsVm : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ProfileImagePath { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(userVm => userVm.Id, opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.Name, opt => opt.MapFrom(user => user.Name))
                .ForMember(userVm => userVm.Description, opt => opt.MapFrom(user => user.Description))
                .ForMember(userVm => userVm.ProfileImagePath, opt => opt.MapFrom(user => user.ProfileImagePath))
                .ForMember(userVm => userVm.DateOfBirth, opt => opt.MapFrom(user => user.DateOfBirth))
                .ForMember(userVm => userVm.DateOfCreation, opt => opt.MapFrom(user => user.DateOfCreation))
                .ForMember(userVm => userVm.Phone, opt => opt.MapFrom(user => user.Phone))
                .ForMember(userVm => userVm.Email, opt => opt.MapFrom(user => user.Email));
        }
    }
}
