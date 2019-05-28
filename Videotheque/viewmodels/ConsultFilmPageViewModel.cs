using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.models;

namespace Videotheque.viewmodels
{
    class ConsultFilmPageViewModel: AbstractModel
    {
        public ConsultFilmPageViewModel(MainViewModel mvm, Film film)
        {
            SuperViewModel = mvm;
            Film = film;
        }

        public MainViewModel SuperViewModel
        {
            get { return GetValue<MainViewModel>(); }
            set { SetValue<MainViewModel>(value); }
        }

        public Film Film
        {
            get { return GetValue<Film>(); }
            set { SetValue<Film>(value); }
        }
    }
}
