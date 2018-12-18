using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MessageAggregator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MessageStore Store { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Store = new MessageStore();
            Store.Tweets.Add(new Tweet("progger", "CSharp", "Learning WPF"));
            Store.Tweets.Add(new Tweet("acc1", "GUI", "Writing GUI with WPF is easy"))
            Store.PostIts.Add(new PostIt("Jef", "PC", "Backup nemen!"));
            Store.PostIts.Add(new PostIt("Bella", "Koelkast", "Winkel passeren!"));
            Store.PostIts.Add(new PostIt("Someone", "Somewhere", "Something"));
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var itemIndex = TweetBox.Items.IndexOf(TweetsBox.SelectedItem);
            var tweet = MessageStore.Tweets[itemIndex];

            Store.Messages.Add(tweet);
            MessagesBox.Items.Add(tweet.HashTag);

            Store.Tweets.RemoveAt(itemIndex);
            TweetsBox.Items.RemoveAt(itemIndex);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var itemIndex = PostitsBox.Items.IndexOf(PostitsBox.SelectedItem);
            var postit = Store.PostIts[itemIndex];

            Store.Messages.Add(postit);
            MessageBox.Items.Add(postit.Location);

            Store.PostIts.RemoveAt(itemIndex);
            PostitsBox.Items.RemoveAt(itemIndex);

        }

        private void PostitsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TweetsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BerichtenBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var itemIndex = BerichtenBox.Items.IndexOf(BerichtenBox.SelectedItem);
            var bericht = Store.Messages[itemIndex];

            InfoBox.Text = bericht.GetMessageInfo();
        }
    }

}
