
namespace MessageAggregator
{
    public class Tweet : IMessage
    {
        public string Message { get; set; }
        public string Account { get; set; }
        public string HashTag { get; set; }

        public Tweet(string account, string hashtag, string message)
        {
            Account = account;
            HashTag = hashtag;
            Message = message;
        }

        public override string ToString()
        {
            return "Tweet - " + HashTag;
        }

        public string GetMessageInfo()
        {
            var result = "--- Tweet ---\n";
            result += "Tweet account: " + Account + "\n";
            result += "HashTag: " + HashTag + "\n";
            result += "Boodschap: " + Message + "\n";
            return result;
        }
    }
}
