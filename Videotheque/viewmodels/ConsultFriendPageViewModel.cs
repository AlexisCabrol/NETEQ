using Videotheque.config;
using Videotheque.models;
using Videotheque.views;

namespace Videotheque.viewmodels
{
    class ConsultFriendPageViewModel : AbstractModel
    {
        public MainViewModel SuperViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }
        public Personne Friend { get { return GetValue<Personne>(); } set { SetValue<Personne>(value); } }
        public ConsultFriendPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
        }

        public void Setup()
        {
            Friend = SuperViewModel.MVMFriend;
        }

        public Command UpdateFriend
        {
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.MVMFriend = Friend;
                    SuperViewModel.Source = NavigationCache.GetPage<AddFriendPage, AddFriendPageViewModel>(SuperViewModel);
                });
            }
        }

        public Command GoBack
        {
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<FriendPage, FriendPageViewModel>(SuperViewModel);
                });
            }
        }
    }
}