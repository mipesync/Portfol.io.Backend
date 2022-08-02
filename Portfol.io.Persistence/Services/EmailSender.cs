using MailKit.Net.Smtp;
using MimeKit;
using Portfol.io.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfol.io.Persistence.Services
{
    public class EmailSender : IEmailSender
    {
        public string Text { get; set; } = "";
        public string Subject { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public string FromAddress { get; set; } = "portfol_io@outlook.com";

        public EmailSender(string toAddress, string fromAddress)
        {
            ToAddress = toAddress;
            FromAddress = fromAddress;
        }

        public async void Send()
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация Porfol.io", "portfol_io@outlook.com"));
            emailMessage.To.Add(new MailboxAddress("", ToAddress));
            emailMessage.Subject = Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = Text
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.office365.com", 587, false);
                await client.AuthenticateAsync("portfol_io@outlook.com", "portfol.io1282asd");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
