using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.config;
using Videotheque.models;
using Videotheque.views;

namespace Videotheque.viewmodels
{
    class ConsultFilmPageViewModel: AbstractModel
    {
        public MainViewModel SuperViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }
        public ConsultFilmPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
        }

        public Film Film
        {
            get { return GetValue<Film>(); }
            set { SetValue<Film>(value); }
        }

        public void Setup()
        {
            Film = SuperViewModel.MVMFilm;
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
