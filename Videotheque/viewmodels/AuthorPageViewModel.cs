using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
    }
}
