using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.config;
using Videotheque.models;
using Videotheque.models.enums;
using Videotheque.services.personne;
using Videotheque.services.personne.impl;
using Videotheque.utils;
using Videotheque.views;

namespace Videotheque.viewmodels
{
    class AddAuthorPageViewModel : AbstractModel
    {
        private readonly PersonneService personneService = new PersonneServiceImpl();
        public MainViewModel SuperViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }
        private bool UpdateMode = false;
        public Personne Author { get { return GetValue<Personne>(); } set { SetValue<Personne>(value); } }
        public List<ComboboxUtils> ListCivilite { get; set; }
        public List<ComboboxUtils> ListNat { get; set; }

        public AddAuthorPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
            ListCivilite = ComboboxUtils.init(new Civilite());
            ListNat = ComboboxUtils.init(new Pays());
        }

        public void Setup()
        {
            if ( SuperViewModel.MVMAuthor != null )
            {
                Author = SuperViewModel.MVMAuthor;
                UpdateMode = true;
            }
            else
            {
                Author = new Personne();
            }
        }

        public void ImageSetup(byte[] array)
        {
            Author.PhotoProfil = array;
        }

        public Command ValidateAuthor
        {
            get
            {
                return new Command(async () =>
                {
                    if (UpdateMode)
                    {
                        await personneService.UpdatePersonne(Author);
                        SuperViewModel.MVMFriend = Author;
                        SuperViewModel.Source = NavigationCache.GetPage<ConsultAuthorPage, ConsultAuthorPageViewModel>(SuperViewModel);
                    }
                    else
                    {
                        await personneService.AddPersonne(Author);
                        SuperViewModel.Source = NavigationCache.GetPage<AuthorPage, AuthorPageViewModel>(SuperViewModel);
                    }
                });
            }
        }

        public Command GoBack
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
