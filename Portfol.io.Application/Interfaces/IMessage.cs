namespace Portfol.io.Application.Interfaces
{
    public interface IMessage
    {
        void Send();
        string ToAddress { get; set; }
        string FromAddress { get; }
    }
}
