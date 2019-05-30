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
    class ConsultAuthorPageViewModel : AbstractModel
    {
        private readonly PersonneService personneService = new PersonneServiceImpl();
        public ConsultAuthorPageViewModel(MainViewModel mvm, Personne personne)
        {
            SuperViewModel = mvm;
            Author = personne;
        }

        public Personne Author
        {
            get { return GetValue<Personne>(); }
            set { SetValue<Personne>(value); }
        }
 
        public MainViewModel SuperViewModel
        {
            get { return GetValue<MainViewModel>(); }
            set { SetValue<MainViewModel>(value); }
        }

        public ObservableCollection<MediaPersonne> AuthorWithHisFilms
        {
            get { return GetValue<ObservableCollection<MediaPersonne>>(); }
            set { SetValue<ObservableCollection<MediaPersonne>>(value); }
        }

        public MediaPersonne CurrentMediaPersonne
        {
            get { return GetValue<MediaPersonne>(); }
            set { SetValue<MediaPersonne>(value); }
        }

        public async void CallService()
        {
            AuthorWithHisFilms = await personneService.SelectAllFilmForOneAuthor(Author.Id);
        }

        public async void DeleteMediaPersonne()
        {
            await personneService.DeleteMediaPersonne(CurrentMediaPersonne);
            CallService();
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
