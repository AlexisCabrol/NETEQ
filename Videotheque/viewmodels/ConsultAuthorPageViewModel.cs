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
        public MainViewModel SuperViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }
        public ObservableCollection<MediaPersonne> AuthorWithHisFilms { get { return GetValue<ObservableCollection<MediaPersonne>>(); } set { SetValue<ObservableCollection<MediaPersonne>>(value); } }
        public MediaPersonne CurrentMediaPersonne { get { return GetValue<MediaPersonne>(); } set { SetValue<MediaPersonne>(value); } }
        public Personne Author { get { return GetValue<Personne>(); } set { SetValue<Personne>(value); } }

        public ConsultAuthorPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
        }

        public void Setup()
        {
            Author = SuperViewModel.MVMAuthor;
            CallService();
        }

        public async void CallService()
        {
            AuthorWithHisFilms = await personneService.SelectAllFilmForOneCollab(Author.Id);
        }

        public async void DeleteMediaPersonne()
        {
            await personneService.DeleteMediaPersonne(CurrentMediaPersonne);
            CallService();
        }

        public Command DeletePers
        {
            get
            {
                return new Command(async () =>
                {
                    await personneService.DeleteCollbaborateurs(Author, AuthorWithHisFilms);
                    SuperViewModel.Source = NavigationCache.GetPage<AuthorPage, AuthorPageViewModel>(SuperViewModel);
                });
            }
        }

        public Command UpdateCollab
        {
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<AddAuthorPage, AddAuthorPageViewModel>(SuperViewModel);
                });
            }
        }

        public Command AddCollab
        {
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<AddCollabPage, AddCollabPageViewModel>(SuperViewModel);
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
