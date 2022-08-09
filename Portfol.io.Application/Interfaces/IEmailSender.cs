namespace Portfol.io.Application.Interfaces
{
    public interface IEmailSender : ITextMessage
    {
        string Subject { get; set; }
    }
}
