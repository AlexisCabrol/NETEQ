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
using Videotheque.viewmodels;

namespace Videotheque.views
{
    /// <summary>
    /// Logique d'interaction pour AddFilmPage.xaml
    /// </summary>
    public partial class AddFilmPage : Page
    {
        private AddFilmPageViewModel ViewModel;
        public AddFilmPage()
        {
            InitializeComponent();
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel = DataContext as AddFilmPageViewModel;
            ViewModel.Setup();
        }
    }
}
