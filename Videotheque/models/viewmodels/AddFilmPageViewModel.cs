using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.config;
using Videotheque.views;

namespace Videotheque.models.viewmodels
{
    class AddFilmPageViewModel : AbstractModel
    {
        public AddFilmPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
            this.Film = new Film();
        }

        public MainViewModel SuperViewModel
        {
            get { return GetValue<MainViewModel>(); }
            set { SetValue<MainViewModel>(value); }
        }

        public Film Film
        {
            get { return GetValue<Film>(); }
            set { SetValue<Film>(value);  }
        }

        public Command AddFilm
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
