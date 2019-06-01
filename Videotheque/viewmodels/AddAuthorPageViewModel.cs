using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.models;

namespace Videotheque.viewmodels
{
    class AddAuthorPageViewModel : AbstractModel
    {
        public MainViewModel SuperViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }
        public AddAuthorPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
        }
    }
}
