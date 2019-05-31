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
using Videotheque.views;

namespace Videotheque.viewmodels
{
    class HomePageViewModel : AbstractModel
    {
        private readonly StatistiquesService statistiquesService = new StatistiqueServiceImpl();
        public HomePageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
        }

        public SeriesCollection MediaPerGenre { get { return GetValue<SeriesCollection>(); } set { SetValue<SeriesCollection>(value); } }
        public int FilmInDatabase { get { return GetValue<int>(); } set { SetValue<int>(value); } }
        public async void BuildStats()
        {
            Dictionary<string, int> statMediaPerGenre = await statistiquesService.FilmPerGenre();
            MediaPerGenre = new SeriesCollection();
            foreach(KeyValuePair<string, int> entry in statMediaPerGenre)
            {
                MediaPerGenre.Add(new PieSeries()
                {
                    Title = entry.Key,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(entry.Value) },
                    DataLabels = true
                });
            }
            FilmInDatabase = await statistiquesService.FilmInDatabase();
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
