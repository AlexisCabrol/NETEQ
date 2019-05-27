using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.config;
using Videotheque.views;

namespace Videotheque.models.viewmodels
{
    class FilmPageViewModel : AbstractModel
    {
        public FilmPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
        }

        public MainViewModel SuperViewModel
        {
            get { return GetValue<MainViewModel>(); }
            set { SetValue<MainViewModel>(value); }
        }

        public Command AddFilm
        {
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<AddFilmPage, AddFilmPageViewModel>(SuperViewModel);
                });
            }
        }
    }
}
