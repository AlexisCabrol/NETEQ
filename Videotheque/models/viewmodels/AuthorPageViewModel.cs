using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.models.viewmodels
{
    class AuthorPageViewModel : AbstractModel
    {
        public AuthorPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
            this.Authors = new ObservableCollection<Personne>();
            this.Authors.Add(new Personne() { Nom = "Cabrol", Prenom = "Alexis" });
            this.Authors.Add(new Personne() { Nom = "Olivaux", Prenom = "Alexandra" });
            this.Authors.Add(new Personne() { Nom = "Lamarre", Prenom = "Laurine" });
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
