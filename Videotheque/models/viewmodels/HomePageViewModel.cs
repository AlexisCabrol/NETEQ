using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.config;
using Videotheque.views;

namespace Videotheque.models.viewmodels
{
    class HomePageViewModel : AbstractModel
    {
        public HomePageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
        }

        public MainViewModel SuperViewModel
        {
            get { return GetValue<MainViewModel>(); }
            set { SetValue<MainViewModel>(value); }
        }

        public Command Film
        {
            get {
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<FilmPage, FilmPageViewModel>(SuperViewModel);
                });
            }
        }

        public Command Author
        {
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<AuthorPage, AuthorPageViewModel>(SuperViewModel);
                });
            }
        }
    }
}
