using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Videotheque.utils;
using Videotheque.viewmodels;

namespace Videotheque.views
{
    /// <summary>
    /// Logique d'interaction pour AddAuthorPage.xaml
    /// </summary>
    public partial class AddAuthorPage : Page
    {
        private AddAuthorPageViewModel ViewModel;
        private OpenFileDialog OpenFileDialog;
        public AddAuthorPage()
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
            ViewModel = DataContext as AddAuthorPageViewModel;
            ViewModel.Setup();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog.ShowDialog();
        }

    }
}
