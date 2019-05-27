using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.config;
using Videotheque.models;
using Videotheque.views;

namespace Videotheque.viewmodels
{
    class FriendPageViewModel: AbstractModel
    {
        public FriendPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
            this.Friends = new ObservableCollection<Personne>();
            this.Friends.Add(new Personne() { Nom = "Cabrol", Prenom = "Alexis" });
            this.Friends.Add(new Personne() { Nom = "Olivaux", Prenom = "Alexandra" });
            this.Friends.Add(new Personne() { Nom = "Lamarre", Prenom = "Laurine" });
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
    }
}
