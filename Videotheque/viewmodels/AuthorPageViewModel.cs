using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Videotheque.models;
using Videotheque.services.personne;
using Videotheque.services.personne.impl;

namespace Videotheque.viewmodels
{
    class AuthorPageViewModel : AbstractModel
    {
        private readonly PersonneService personneService = new PersonneServiceImpl();

        public AuthorPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
        }

        public async void CallService()
        {
            this.Authors = await personneService.SelectAllAuthor();
        }

        public async void DeleteAuthor()
        {
            await personneService.DeleteAuthor(CurrentAuthor);
            CallService();
        }

        public async void SearchByText(string text)
        {
            Authors = await personneService.SelectAuthorFilter(text);
        }

        public MainViewModel SuperViewModel
        {
            get { return GetValue<MainViewModel>(); }
            set { SetValue<MainViewModel>(value); }
        }

        public ObservableCollection<Personne> Authors
        {
            get { return GetValue<ObservableCollection<Personne>>(); }
            set { SetValue<ObservableCollection<Personne>>(value); }
        }

        public Personne CurrentAuthor
        {
            get { return GetValue<Personne>(); }
            set { SetValue<Personne>(value); }
        }
    }
}
