using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Videotheque.viewmodels;

namespace Videotheque.views
{
    /// <summary>
    /// Logique d'interaction pour FriendPage.xaml
    /// </summary>
    public partial class FriendPage : Page
    {
        private FriendPageViewModel ViewModel;
        public FriendPage()
        {
            InitializeComponent();
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            this.ViewModel = DataContext as FriendPageViewModel;
            ViewModel.CallService();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Search = SearchText.Text.Trim();

            if (!String.IsNullOrEmpty(Search))
            {
                ViewModel.SearchByText(Search);
            }
            else
            {
                ViewModel.CallService();
            }
        }

        private void TrierFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFilterList(FilterBox.SelectedIndex);
        }

        private void UpdateFilterList(int statut)
        {
            switch (statut)
            {
                case 0:
                    ViewModel.Friends = new ObservableCollection<Personne>(
                        ViewModel.Friends.OrderBy(p => p.GetIdentity()).ToList());
                    break;
                case 1:
                    ViewModel.Friends = new ObservableCollection<Personne>(
                        ViewModel.Friends.OrderByDescending(p => p.GetIdentity()).ToList());
                    break;
                default:
                    ViewModel.CallService();
                    break;
            }
        }

        private void DeleteFriendBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteFriend();
            UpdateFilterList(FilterBox.SelectedIndex);
            SearchText.Text = "";
        }

        private void ListFriend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListFriend.SelectedItem != null)
            {
                DeleteFriendBtn.IsEnabled = true;
            }
            else
            {
                DeleteFriendBtn.IsEnabled = false;
            }
        }
    }
}
