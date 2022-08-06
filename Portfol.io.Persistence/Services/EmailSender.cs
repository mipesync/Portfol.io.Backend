using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Portfol.io.Application.Interfaces;

namespace Portfol.io.Persistence.Services
{
    public class EmailSender : IEmailSender
    {
        public string Text { get; set; } = "";
        public string Subject { get; set; } = "";
        public string ToAddress { get; set; } = "";
        private string FromAddress { get; set; }

        private readonly IConfigSectionGetter _sectionGetter;

        public EmailSender(IConfigSectionGetter sectionGetter)
        {
            _sectionGetter = sectionGetter;
            FromAddress = _sectionGetter.GetSection("Smtp:Authenticate:Username");
        }

        public async void Send()
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация Porfol.io", FromAddress));
            emailMessage.To.Add(new MailboxAddress("", ToAddress));
            emailMessage.Subject = Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = Text
            };

            using (var client = new SmtpClient())
            {
                string host = _sectionGetter.GetSection("Smtp:Connect:Host"),
                    password = _sectionGetter.GetSection("Smtp:Authenticate:Password");
                int port = Convert.ToInt32(_sectionGetter.GetSection("Smtp:Connect:Port"));

                await client.ConnectAsync(host, port, false);
                await client.AuthenticateAsync(FromAddress, password);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
