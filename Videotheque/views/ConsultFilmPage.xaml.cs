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
    /// Logique d'interaction pour ConsultFilmPage.xaml
    /// </summary>
    public partial class ConsultFilmPage : Page
    {
        private ConsultFilmPageViewModel ViewModel;
        public ConsultFilmPage()
        {
            InitializeComponent();
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            this.ViewModel = DataContext as ConsultFilmPageViewModel;
            ViewModel.Setup();
        }
    }
}
