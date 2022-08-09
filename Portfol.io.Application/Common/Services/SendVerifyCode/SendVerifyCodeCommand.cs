using MediatR;

namespace Portfol.io.Application.Common.Services.SendVerifyCode
{
    public class SendVerifyCodeCommand : IRequest<Unit>
    {
        public SendVerifyCodeViewModel Model { get; set; } = null!;
    }
}
