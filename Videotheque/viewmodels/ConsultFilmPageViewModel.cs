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
        public ConsultFilmPageViewModel(MainViewModel mvm, Film film)
        {
            SuperViewModel = mvm;
            Film = film;
        }

        public Film Film
        {
            get { return GetValue<Film>(); }
            set { SetValue<Film>(value); }
        }

        public Command UpdateFilm
        {
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<AddFilmPage, AddFilmPageViewModel>(SuperViewModel, Film);
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
