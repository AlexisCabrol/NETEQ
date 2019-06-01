using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Videotheque.models;

namespace Videotheque.viewmodels
{
    class MainViewModel : AbstractModel
    {
        public Page Source { get { return GetValue<Page>(); } set { SetValue<Page>(value); } }
        public Film MVMFilm { get { return GetValue<Film>(); } set { SetValue<Film>(value); } }
        public Personne MVMFriend { get { return GetValue<Personne>(); } set { SetValue<Personne>(value); } }
    }
}
