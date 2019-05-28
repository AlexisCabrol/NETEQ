using System;
using System.Collections.Generic;
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
        private FilmPageViewModel ValueModel;
        public FilmPage()
        {
            InitializeComponent();
            this.ListFilmStart = new List<Film>();
        }

        private List<Film> ListFilmStart
        {
            get; set;
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            this.ValueModel = DataContext as FilmPageViewModel;
            ValueModel.CallService();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Search = SearchText.Text.Trim();
            FirstCall();

            if (!String.IsNullOrEmpty(Search))
            {
                ListFilm.ItemsSource = ListFilmStart.FindAll(film => film.Titre.ToLower().Contains(Search.ToLower()));
            }
            else
            {
                ListFilm.ItemsSource = ListFilmStart;
            }
        }

        private void TrierFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FirstCall();

            List<Film> sortedList = ListFilmStart;
            switch (FilterBox.SelectedIndex)
            {
                case 0:
                    sortedList.Sort();
                    ListFilm.ItemsSource = sortedList;
                    ListFilm.Items.Refresh();
                    break;
                case 1:
                    sortedList.Sort();
                    sortedList.Reverse();
                    ListFilm.ItemsSource = sortedList;
                    ListFilm.Items.Refresh();
                    break;
                default:
                    ListFilm.ItemsSource = ListFilmStart;
                    break;
            }
        }

        private void FirstCall()
        {
            if (!ListFilmStart.Any())
            {
                this.ListFilmStart = ListFilm.Items.OfType<Film>().ToList();
            }
        }

        private void ListFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListFilm.SelectedItem != null)
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
            UpdateFilmBtn.IsEnabled = visible;
            DeleteFilmBtn.IsEnabled = visible;
        }

        private void DeleteFilmBtn_Click(object sender, RoutedEventArgs e)
        {
            ValueModel.DeleteFilm();
        }
    }
}
