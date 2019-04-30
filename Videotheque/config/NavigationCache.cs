using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Videotheque.models;

namespace Videotheque.config
{
    class NavigationCache
    {
        private static Dictionary<Type, object> _viewsCache = new Dictionary<Type, object>();
        private static Dictionary<Type, AbstractModel> _ViewModelCache =
            new Dictionary<Type, AbstractModel>();

        private static TViewModel GetViewModelInstance<TViewModel>(params object[] viewModelParameters)
            where TViewModel : AbstractModel
        {
            return (TViewModel)GetViewModelInstance(typeof(TViewModel), viewModelParameters);
        }
        private static object GetViewModelInstance(Type tViewModel,
                                                   params object[] viewModelParameters)
        {
            object vm = null;
            if (_ViewModelCache.ContainsKey(tViewModel))
                vm = _ViewModelCache[tViewModel];
            else
            {
                vm = Activator.CreateInstance(tViewModel, viewModelParameters);
                _ViewModelCache[tViewModel] = (AbstractModel)vm;
            }
            return vm;
        }

        private static TView GetViewInstance<TView>(object viewModel)
            where TView : class
        {
            return (TView)GetViewInstance(typeof(TView), viewModel);
        }
        private static object GetViewInstance(Type tView, object viewModel)
        {
            object view = null;
            bool isWindow = tView.BaseType == typeof(Window);
            if (!isWindow && _viewsCache.ContainsKey(tView))
                view = _viewsCache[tView];
            else
            {
                view = Activator.CreateInstance(tView);
                var prop = tView.GetProperty("DataContext");
                prop?.SetValue(view, viewModel);
                if (!isWindow)
                    _viewsCache[tView] = view;
            }
            return view;
        }

        public static TView GetPage<TView, TViewModel>(params object[] viewModelParameters)
            where TView : Page
            where TViewModel : AbstractModel
        {
            return GetViewInstance<TView>(
                GetViewModelInstance<TViewModel>(viewModelParameters));
        }

        public static TView Show<TView, TViewModel>(params object[] viewModelParameters)
            where TView : Window
            where TViewModel : AbstractModel
        {
            var vm = GetViewModelInstance<TViewModel>(viewModelParameters);
            var view = GetViewInstance<TView>(vm);
            view.Show();
            return view;
        }
        public static void Close(Window view, bool? result = null)
        {
            if (result != null)
                view.DialogResult = result;
            view.Close();
        }

        public static bool? ShowDialog<TView, TViewModel>(params object[] viewModelParameters)
            where TView : Window
            where TViewModel : AbstractModel
        {
            var vm = GetViewModelInstance<TViewModel>(viewModelParameters);
            var view = GetViewInstance<TView>(vm);
            return view.ShowDialog();
        }

    }
}

