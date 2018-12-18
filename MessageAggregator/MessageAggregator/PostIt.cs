
namespace MessageAggregator
{
    public class PostIt : IMessage
    {
        public string From { get; set; }
        public string Location { get; set; }

        public PostIt(string from, string location, string message)
        {
            From = from;
            Location = location;
            Message = message;
        }

        public override string ToString()
        {
            return "PostIt - " + Location;
        }

        public string GetMessageInfo()
        {
            result = "--- PostIt ---\n";
            result += "Van: " + From + "\n";
            result += "Locatie: " + Location + "\n";
            result += "Boodschap: " + Message + "\n";
            return result;
        }
    }
}
