using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.config;
using Videotheque.models;
using Videotheque.services.film;
using Videotheque.services.film.impl;
using Videotheque.services.personne;
using Videotheque.services.personne.impl;
using Videotheque.views;

namespace Videotheque.viewmodels
{
    class ConsultFilmPageViewModel: AbstractModel
    {
        private readonly FilmService filmService = new FilmServiceImpl();
        public MainViewModel SuperViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }
        public ObservableCollection<MediaPersonne> FilmWithHisCollabs { get { return GetValue < ObservableCollection<MediaPersonne>>(); } set { SetValue<ObservableCollection<MediaPersonne>>(value); } }
        public ConsultFilmPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
        }

        public Film Film
        {
            get { return GetValue<Film>(); }
            set { SetValue<Film>(value); }
        }

        public async void Setup()
        {
            Film = SuperViewModel.MVMFilm;
            FilmWithHisCollabs = await filmService.SelectAllCollabForOneFilm(Film.Id);
        }

        public Command UpdateFilm
        {
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.MVMFilm = Film;
                    SuperViewModel.Source = NavigationCache.GetPage<AddFilmPage, AddFilmPageViewModel>(SuperViewModel);
                });
            }
        }

        public Command GoBack
        {
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<FilmPage, FilmPageViewModel>(SuperViewModel);
                });
            }
        }
    }
}
