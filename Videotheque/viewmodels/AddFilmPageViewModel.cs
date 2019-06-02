using System;
using System.Collections.Generic;
using Videotheque.config;
using Videotheque.models;
using Videotheque.models.enums;
using Videotheque.services.film;
using Videotheque.services.film.impl;
using Videotheque.utils;
using Videotheque.views;

namespace Videotheque.viewmodels
{
    class AddFilmPageViewModel : AbstractModel
    {
        private readonly FilmService filmService = new FilmServiceImpl();
        private Boolean UpdateMode = false;
        public List<ComboboxUtils> ListVO { get; set; }
        public List<ComboboxUtils> ListME { get; set; }
        public List<ComboboxUtils> ListStatut { get; set; }
        public Film Film { get { return GetValue<Film>(); } set { SetValue<Film>(value); } }
        public MainViewModel SuperViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }

        public AddFilmPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
            ListVO = ComboboxUtils.init(new Pays());
            ListME = ComboboxUtils.init(new Pays());
            ListStatut = ComboboxUtils.init(new Statut());
        }

        public void Setup()
        {
            if (SuperViewModel.MVMFilm != null)
            {
                Film = SuperViewModel.MVMFilm;
                UpdateMode = true;
            }
            else
            {
                Film = new Film();
            }
        }

        public Command ValidateFilm
        {
            get
            {
                return new Command(async () =>
                {
                    if (UpdateMode)
                    {
                        await filmService.UpdateFilm(Film);
                        SuperViewModel.MVMFilm = Film;
                        SuperViewModel.Source = NavigationCache.GetPage<ConsultFilmPage, ConsultFilmPageViewModel>(SuperViewModel);
                    }
                    else
                    {
                        await filmService.AddFilm(Film);
                        SuperViewModel.Source = NavigationCache.GetPage<FilmPage, FilmPageViewModel>(SuperViewModel);
                    }
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
