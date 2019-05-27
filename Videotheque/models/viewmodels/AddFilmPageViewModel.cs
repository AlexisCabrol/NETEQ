using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.models.viewmodels
{
    class AddFilmPageViewModel : AbstractModel
    {
        public AddFilmPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
        }

        public MainViewModel SuperViewModel
        {
            get { return GetValue<MainViewModel>(); }
            set { SetValue<MainViewModel>(value); }
        }
    }
}
