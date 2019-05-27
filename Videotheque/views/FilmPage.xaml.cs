using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Videotheque.models;

namespace Videotheque.views
{
    /// <summary>
    /// Logique d'interaction pour FilmPage.xaml
    /// </summary>
    public partial class FilmPage : Page
    {
        public FilmPage()
        {
            InitializeComponent();
            this.ListFilmStart = new List<Film>();
        }

        private List<Film> ListFilmStart
        {
            get; set;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Search = SearchText.Text.Trim();
            firstCall();

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
            firstCall();

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

        private void firstCall()
        {
            if (!ListFilmStart.Any())
            {
                this.ListFilmStart = ListFilm.Items.OfType<Film>().ToList();
            }
        }
    }
}
