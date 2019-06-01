using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.config;
using Videotheque.models;
using Videotheque.services.personne;
using Videotheque.services.personne.impl;
using Videotheque.views;

namespace Videotheque.viewmodels
{
    class FriendPageViewModel: AbstractModel
    {
        private readonly PersonneService personneService = new PersonneServiceImpl();
        public FriendPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
        }

        public MainViewModel SuperViewModel
        {
            get { return GetValue<MainViewModel>(); }
            set { SetValue<MainViewModel>(value); }
        }

        public ObservableCollection<Personne> Friends
        {
            get { return GetValue<ObservableCollection<Personne>>(); }
            set { SetValue<ObservableCollection<Personne>>(value); }
        }

        public Personne CurrentFriend
        {
            get { return GetValue<Personne>(); }
            set { SetValue<Personne>(value); }
        }

        public async void CallService()
        {
            Friends = await personneService.SelectAllFriend();
        }

        public async void SearchByText(string text)
        {
            Friends = await personneService.SelectFriendFilter(text);
        }

        public async void DeleteFriend()
        {
            await personneService.DeleteFriend(CurrentFriend);
            CallService();
        }

        public Command AddFriend
        {
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<AddFriendPage, AddFriendPageViewModel>(SuperViewModel);
                });
            }
        }

        public Command GoBack
        {
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<HomePage, HomePageViewModel>(SuperViewModel);
                });
            }
        }
    }
}
