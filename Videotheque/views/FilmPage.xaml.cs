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
    /// Logique d'interaction pour FilmPage.xaml
    /// </summary>
    public partial class FilmPage : Page
    {
        private FilmPageViewModel ViewModel;
        public FilmPage()
        {
            InitializeComponent();
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            this.ViewModel = DataContext as FilmPageViewModel;
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
                    ViewModel.Films = new ObservableCollection<Film>(
                        ViewModel.Films.OrderBy(film => film.Titre).ToList());
                    break;
                case 1:
                    ViewModel.Films = new ObservableCollection<Film>(
                        ViewModel.Films.OrderByDescending(film => film.Titre).ToList());
                    break;
                default:
                    ViewModel.CallService();
                    break;
            }
        }

        private void ListFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListFilm.SelectedItem != null)
            {
                UpdateEnabledBtn(true);
            }
            else
            {
                UpdateEnabledBtn(false);
            }
        }

        private void UpdateEnabledBtn(bool visible)
        {
            ConsultFilmBtn.IsEnabled = visible;
            DeleteFilmBtn.IsEnabled = visible;
        }

        private void DeleteFilmBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteFilm();
            UpdateFilterList(FilterBox.SelectedIndex);
            SearchText.Text = "";
        }
    }
}
