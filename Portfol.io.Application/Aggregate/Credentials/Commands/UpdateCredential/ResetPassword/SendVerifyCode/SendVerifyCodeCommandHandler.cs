using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential.ResetPassword.SendVerifyCode
{
    public class SendVerifyCodeCommandHandler : IRequestHandler<SendVerifyCodeCommand, string>
    {
        private readonly IEmailSender _emailSender;
        private readonly IPortfolioDbContext _dbContext;

        public SendVerifyCodeCommandHandler(IEmailSender emailSender, IPortfolioDbContext dbContext)
        {
            _emailSender = emailSender;
            _dbContext = dbContext;
        }

        public async Task<string> Handle(SendVerifyCodeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (entity == null || entity.Email != request.Email) throw new NotFoundException(nameof(Users), request.Email);

            var verifyCode = new Random().Next(100000, 999999).ToString();

            _emailSender.Text = $"Ваш код подтверждения: {verifyCode}";
            _emailSender.Subject = "Сброс пароля";
            _emailSender.ToAddress = entity.Email;
            _emailSender.Send();

            return verifyCode;
        }
    }
}
