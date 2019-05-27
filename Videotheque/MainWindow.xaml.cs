using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Videotheque.config;
using Videotheque.viewmodels;
using Videotheque.views;

namespace Videotheque
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var mvm = new MainViewModel();
            mvm.Source = NavigationCache.GetPage<HomePage, HomePageViewModel>(mvm);
            this.DataContext = mvm;
        }
    }
}
