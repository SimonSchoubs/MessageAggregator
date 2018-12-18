using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MessageAggregator
{
    public partial class MainWindow : Window
    {
        private MessageStore Store { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            initializeStore();
            initializeListBoxes();
        }

        private void initializeStore()
        {
            var tweets = new List<Tweet> {
                new Tweet("progger", "CSharp", "Learning WPF"),
                new Tweet("acc1", "GUI", "Writing GUI with WPF is easy")
            };
            var postits = new List<PostIt> {
                new PostIt("Jef", "PC", "Backup nemen!"),
                new PostIt("Bella", "Koelkast", "Winkel passeren!"),
                new PostIt("Someone", "Somewhere", "Something")
            };
            Store = new MessageStore(tweets, postits);
        }

        private void initializeListBoxes()
        {
            foreach (var tweet in Store.Tweets)
            {
                TweetsBox.Items.Add(tweet.ToString());
            }
            foreach (var postit in Store.PostIts)
            {
                PostitsBox.Items.Add(postit.ToString());
            }
        }

        private void StuurTweet_Click(object sender, RoutedEventArgs e)
        {
            var itemIndex = TweetsBox.Items.IndexOf(TweetsBox.SelectedItem);
            var tweet = Store.Tweets[itemIndex];

            Store.Messages.Add(tweet);
            BerichtenBox.Items.Add(tweet.HashTag);

            Store.Tweets.RemoveAt(itemIndex);
            TweetsBox.Items.RemoveAt(itemIndex);
        }

        private void PlakPostit_Click(object sender, RoutedEventArgs e)
        {
            var itemIndex = PostitsBox.Items.IndexOf(PostitsBox.SelectedItem);
            var postit = Store.PostIts[itemIndex];

            Store.Messages.Add(postit);
            BerichtenBox.Items.Add(postit.Location);

            Store.PostIts.RemoveAt(itemIndex);
            PostitsBox.Items.RemoveAt(itemIndex);

        }

        private void BerichtenBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var itemIndex = BerichtenBox.Items.IndexOf(BerichtenBox.SelectedItem);
            var bericht = Store.Messages[itemIndex];

            InfoBox.Text = bericht.GetMessageInfo();
        }
    }
}
