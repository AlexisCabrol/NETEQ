using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.config;
using Videotheque.views;
using System.Collections.ObjectModel;
using Videotheque.models;

namespace Videotheque.viewmodels
{
    class FilmPageViewModel : AbstractModel
    {
        public FilmPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
            this.Films = new ObservableCollection<Film>();
            this.Films.Add(new Film() { Titre = "Un film de test 1" });
            this.Films.Add(new Film() { Titre = "TEST" });
            this.Films.Add(new Film() { Titre = "Un test 2" });
        }

        public MainViewModel SuperViewModel
        {
            get { return GetValue<MainViewModel>(); }
            set { SetValue<MainViewModel>(value); }
        }

        public ObservableCollection<Film> Films
        {
            get { return GetValue<ObservableCollection<Film>>();  }
            set { SetValue<ObservableCollection<Film>>(value);  }
        }

        public Command UpdateFilm
        {
            // TODO
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<AddFilmPage, AddFilmPageViewModel>(SuperViewModel);
                });
            }
        }

        public Command DeleteFilm
        {
            // TODO
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<AddFilmPage, AddFilmPageViewModel>(SuperViewModel);
                });
            }
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
