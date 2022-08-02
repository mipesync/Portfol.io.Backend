using AutoMapper;
using Portfol.io.Application.Common.Mappings;
using Portfol.io.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential.ResetPassword
{
    public class ResetPasswordViewModel : IMapWith<Credential>
    {
        public string Username { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public int Code { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ResetPasswordViewModel, Credential>()
                .ForMember(cred => cred.Username, opt => opt.MapFrom(resPassVm => resPassVm.Username))
                .ForMember(cred => cred.Password, opt => opt.MapFrom(resPassVm => resPassVm.NewPassword));
        }
    }
}
