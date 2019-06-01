using System.Collections.Generic;
using Videotheque.config;
using Videotheque.models;
using Videotheque.models.enums;
using Videotheque.services.personne;
using Videotheque.services.personne.impl;
using Videotheque.utils;
using Videotheque.views;

namespace Videotheque.viewmodels
{
    class AddFriendPageViewModel : AbstractModel
    {
        private readonly PersonneService personneService = new PersonneServiceImpl();
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public List<ComboboxUtils> ListCivilite { get; set; }
        public List<ComboboxUtils> ListNat { get; set; }

        public MainViewModel SuperViewModel
        {
            get { return GetValue<MainViewModel>(); }
            set { SetValue<MainViewModel>(value); }
        }

        public Civilite CivEnum
        {
            get { return GetValue<Civilite>(); }
            set { SetValue<Civilite>(value); }
        }

        public Pays NatEnum
        {
            get { return GetValue<Pays>(); }
            set { SetValue<Pays>(value); }
        }

        public AddFriendPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
            ListCivilite = ComboboxUtils.init(new Civilite());
            ListNat = ComboboxUtils.init(new Pays());
        }

        public Command ValidateFriend
        {
            get
            {
                return new Command(async () =>
                {
                    await personneService.AddFriend(new Personne()
                    {
                        Nom = this.Nom,
                        Prenom = this.Prenom,
                        Civilite = this.CivEnum,
                        Nationalite = this.NatEnum,
                        Ami = true
                    });
                    SuperViewModel.Source = NavigationCache.GetPage<FriendPage, FriendPageViewModel>(SuperViewModel);
                });
            }
        }
    }
}
