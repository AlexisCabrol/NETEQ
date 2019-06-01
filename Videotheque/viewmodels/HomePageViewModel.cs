using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.config;
using Videotheque.models;
using Videotheque.services.stats;
using Videotheque.services.stats.impl;
using Videotheque.utils;
using Videotheque.views;

namespace Videotheque.viewmodels
{
    class HomePageViewModel : AbstractModel
    {
        private readonly StatistiquesService statistiquesService = new StatistiqueServiceImpl();
        public MainViewModel SuperViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }

        public HomePageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
        }

        public SeriesCollection MediaPerGenre { get { return GetValue<SeriesCollection>(); } set { SetValue<SeriesCollection>(value); } }
        public SeriesCollection MediaStatut { get { return GetValue<SeriesCollection>(); } set { SetValue<SeriesCollection>(value); } }
        public int FilmInDatabase { get { return GetValue<int>(); } set { SetValue<int>(value); } }
        public async void BuildStats()
        {
            // Build stat media per genre
            Dictionary<string, int> statMediaPerGenre = await statistiquesService.FilmPerGenre();
            MediaPerGenre = StatistiqueUtils.BuildSeriesCollection(statMediaPerGenre);

            // Build stat media statut
            Dictionary<string, int> statMediaStatut = await statistiquesService.FilmStatut();
            MediaStatut = StatistiqueUtils.BuildSeriesCollection(statMediaStatut);

            // Build stat number of film in database
            FilmInDatabase = await statistiquesService.FilmInDatabase();
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

        public Command Friend
        {
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<FriendPage, FriendPageViewModel>(SuperViewModel);
                });
            }
        }
    }
}
