using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Common.Services.SendVerifyCode
{
    public class SendVerifyCodeCommandHandler : IRequestHandler<SendVerifyCodeCommand, Unit>
    {
        private readonly IEmailSender _emailSender;
        private readonly IPortfolioDbContext _dbContext;

        public SendVerifyCodeCommandHandler(IEmailSender emailSender, IPortfolioDbContext dbContext)
        {
            _emailSender = emailSender;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(SendVerifyCodeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (entity == null || entity.Email != request.Email) throw new NotFoundException(nameof(User), request.Email);

            var verifyCode = new Random().Next(100000, 999999).ToString();

            _emailSender.Text = $"{request.MessageText}: {verifyCode}";
            _emailSender.Subject = request.MessageSubject;
            _emailSender.ToAddress = request.Email;
            _emailSender.Send();

            entity.VerifyCode = verifyCode;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
