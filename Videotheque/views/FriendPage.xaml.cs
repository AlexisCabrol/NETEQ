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
using Videotheque.models;

namespace Videotheque.views
{
    /// <summary>
    /// Logique d'interaction pour FriendPage.xaml
    /// </summary>
    public partial class FriendPage : Page
    {
        public FriendPage()
        {
            InitializeComponent();
            this.ListFriendStart = new List<Personne>();
        }

        private List<Personne> ListFriendStart
        {
            get; set;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Search = SearchText.Text.Trim();
            firstCall();

            if (!String.IsNullOrEmpty(Search))
            {
                ListFriend.ItemsSource = ListFriendStart.FindAll(author => author.GetIdentity().ToLower().Contains(Search.ToLower()));
            }
            else
            {
                ListFriend.ItemsSource = ListFriendStart;
            }
        }

        private void TrierFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            firstCall();

            List<Personne> sortedList = ListFriendStart;
            switch (FilterBox.SelectedIndex)
            {
                case 0:
                    sortedList.Sort();
                    ListFriend.ItemsSource = sortedList;
                    ListFriend.Items.Refresh();
                    break;
                case 1:
                    sortedList.Sort();
                    sortedList.Reverse();
                    ListFriend.ItemsSource = sortedList;
                    ListFriend.Items.Refresh();
                    break;
                default:
                    ListFriend.ItemsSource = ListFriendStart;
                    break;
            }
        }

        private void firstCall()
        {
            if (!ListFriendStart.Any())
            {
                this.ListFriendStart = ListFriend.Items.OfType<Personne>().ToList();
            }
        }
    }
}
