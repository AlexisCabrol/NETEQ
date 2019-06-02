using Microsoft.Win32;
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
using Videotheque.utils;
using Videotheque.viewmodels;

namespace Videotheque.views
{
    /// <summary>
    /// Logique d'interaction pour AddFriendPage.xaml
    /// </summary>
    public partial class AddFriendPage : Page
    {
        private AddFriendPageViewModel ViewModel;
        private OpenFileDialog OpenFileDialog;
        public AddFriendPage()
        {
            InitializeComponent();
            OpenFileDialog = FileUtils.InitOpenFileDialog();
            OpenFileDialog.FileOk += (s, o) =>
            {
                ViewModel.ImageSetup(FileUtils.ImageToByteArray(System.Drawing.Image.FromFile(OpenFileDialog.FileName)));
            };
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel = DataContext as AddFriendPageViewModel;
            ViewModel.Setup();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog.ShowDialog();
        }
    }
}
