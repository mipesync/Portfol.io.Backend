using AutoMapper;
using Portfol.io.Application.Common.Mappings;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Credentials.Queries.GetCredentialByUsername
{
    public class CredentialUsernameVm : IMapWith<Credential>
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Credential, CredentialUsernameVm>()
                .ForMember(credVm => credVm.Id, opt => opt.MapFrom(cred => cred.Id))
                .ForMember(credVm => credVm.Username, opt => opt.MapFrom(cred => cred.Username))
                .ForMember(credVm => credVm.Password, opt => opt.MapFrom(cred => cred.Password));
        }
    }
}
