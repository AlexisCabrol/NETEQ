using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videotheque.config;
using Videotheque.models;
using Videotheque.models.enums;
using Videotheque.utils;
using Videotheque.views;

namespace Videotheque.viewmodels
{
    class AddFriendPageViewModel : AbstractModel
    {
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
            ListCivilite = new List<ComboboxUtils>()
        {
            new ComboboxUtils() { ValueEnum = Civilite.Monsieur, ValueString = "Monsieur" },
            new ComboboxUtils() { ValueEnum = Civilite.Madame, ValueString = "Madame" },
            new ComboboxUtils() { ValueEnum = Civilite.Mademoiselle, ValueString = "Mademoiselle" }
        };
            ListNat = new List<ComboboxUtils>()
        {
            new ComboboxUtils() { ValueEnum = Pays.Français, ValueString = "Français" },
            new ComboboxUtils() { ValueEnum = Pays.Allemand, ValueString = "Allemand" },
            new ComboboxUtils() { ValueEnum = Pays.Anglais, ValueString = "Anglais" }
        };
        }

        public Command ValidateFriend
        {
            get
            {
                return new Command(async () =>
                {
                    await saveFriendAsync();
                    SuperViewModel.Source = NavigationCache.GetPage<FriendPage, FriendPageViewModel>(SuperViewModel);
                });
            }
        }

        private async Task saveFriendAsync()
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            context.Personne.Add(new Personne()
            {
                Nom = this.Nom,
                Prenom = this.Prenom,
                Civilite = this.CivEnum,
                Nationalite = this.NatEnum
            });
            await context.SaveChangesAsync();
        }
    }
}
