using MediatR;

namespace Portfol.io.Application.Common.Services.SendVerifyCode
{
    public class SendVerifyCodeCommand : IRequest<Unit>
    {
        public string Email { get; set; } = null!;
        public string MessageText { get; set; } = null!;
        public string MessageSubject { get; set; } = null!;
    }
}
