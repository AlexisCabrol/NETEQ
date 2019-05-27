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
    /// Logique d'interaction pour AuthorPage.xaml
    /// </summary>
    public partial class AuthorPage : Page
    {
        public AuthorPage()
        {
            InitializeComponent();
            this.ListAuthorStart = new List<Personne>();
        }

        private List<Personne> ListAuthorStart
        {
            get; set;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Search = SearchText.Text.Trim();
            firstCall();

            if (!String.IsNullOrEmpty(Search))
            {
                ListAuthors.ItemsSource = ListAuthorStart.FindAll(author => author.GetIdentity().ToLower().Contains(Search.ToLower()));
            }
            else
            {
                ListAuthors.ItemsSource = ListAuthorStart;
            }
        }

        private void TrierFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            firstCall();

            List<Personne> sortedList = ListAuthorStart;
            switch (FilterBox.SelectedIndex)
            {
                case 0:
                    sortedList.Sort();
                    ListAuthors.ItemsSource = sortedList;
                    ListAuthors.Items.Refresh();
                    break;
                case 1:
                    sortedList.Sort();
                    sortedList.Reverse();
                    ListAuthors.ItemsSource = sortedList;
                    ListAuthors.Items.Refresh();
                    break;
                default:
                    ListAuthors.ItemsSource = ListAuthorStart;
                    break;
            }
        }

        private void firstCall()
        {
            if (!ListAuthorStart.Any())
            {
                this.ListAuthorStart = ListAuthors.Items.OfType<Personne>().ToList();
            }
        }
    }
}
