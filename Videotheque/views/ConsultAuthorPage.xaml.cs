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
    /// Logique d'interaction pour ConsultAuthorPage.xaml
    /// </summary>
    public partial class ConsultAuthorPage : Page
    {
        private ConsultAuthorPageViewModel ViewModel;
        public ConsultAuthorPage()
        {
            InitializeComponent();
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            this.ViewModel = DataContext as ConsultAuthorPageViewModel;
            ViewModel.CallService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteMediaPersonne();
        }

        private void ListMediaPersonne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListMediaPersonne.SelectedItem != null)
            {
                DeleteBtn.IsEnabled = true;
            }
            else
            {
                DeleteBtn.IsEnabled = false;
            }
        }
    }
}
