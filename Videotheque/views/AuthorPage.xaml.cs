using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Videotheque.models;
using Videotheque.viewmodels;

namespace Videotheque.views
{
    /// <summary>
    /// Logique d'interaction pour AuthorPage.xaml
    /// </summary>
    public partial class AuthorPage : Page
    {
        private AuthorPageViewModel ViewModel;
        public AuthorPage()
        {
            InitializeComponent();
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            this.ViewModel = DataContext as AuthorPageViewModel;
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
                    ViewModel.Authors = new ObservableCollection<Personne>(
                        ViewModel.Authors.OrderBy(author => author.GetIdentity()).ToList());
                    break;
                case 1:
                    ViewModel.Authors = new ObservableCollection<Personne>(
                        ViewModel.Authors.OrderByDescending(author => author.GetIdentity()).ToList());
                    break;
                default:
                    ViewModel.CallService();
                    break;
            }
        }

        private void UpdateEnabledBtn(bool visible)
        {
            UpdateAuthorBtn.IsEnabled = visible;
            DeleteAuthorBtn.IsEnabled = visible;
        }

        private void DeleteAuthorBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteAuthor();
            UpdateFilterList(FilterBox.SelectedIndex);
            SearchText.Text = "";
        }

        private void ListAuthors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListAuthors.SelectedItem != null)
            {
                UpdateEnabledBtn(true);
            }
            else
            {
                UpdateEnabledBtn(false);
            }
        }
    }
}
