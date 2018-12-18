using System.Collections.Generic;

namespace MessageAggregator
{
    public class MessageStore
    {
        public List<Tweet> Tweets { get; set; }
        public List<PostIt> PostIts { get; set; }
        public List<IMessage> Messages { get; set; }

        public MessageStore(List<Tweet> tweets, List<PostIt> postits)
        {
            Tweets = tweets;
            PostIts = postits;
            Messages = new List<IMessage>();
        }

        public void AddMessage(IMessage message)
        {
            Messages.Add(message);
        }
    }
}
