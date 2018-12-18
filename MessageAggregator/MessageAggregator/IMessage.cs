
namespace MessageAggregator
{
    public interface IMessage
    {
        string Message { get; set; }

        string GetMessageInfo();
    }
}
