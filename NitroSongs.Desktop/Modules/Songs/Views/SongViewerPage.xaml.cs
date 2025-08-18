using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using NitroSongs.Common.Dtos;
using NitroSongs.Modules.Songs.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks.Sources;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NitroSongs.Modules.Songs.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SongViewerPage : Page
    {
        public SongViewerViewModel ViewModel;
        public SongViewerPage()
        {
            InitializeComponent();

            ViewModel = App.AppHost.Services.GetRequiredService<SongViewerViewModel>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is SongDto song)
                ViewModel.Lyrics = song.Lyrics;
        }

        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.IsViewMode)
            {
                EditBtn.Background = new SolidColorBrush(Colors.Transparent);
                ViewBtn.Background = new SolidColorBrush(ColorHelper.FromArgb(0xFF, 59, 130, 246));
               

                ViewModel.ChangeModeCommand.Execute(null);
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.IsEditMode)
            {
                EditBtn.Background = new SolidColorBrush(ColorHelper.FromArgb(0xFF, 59, 130, 246));
                ViewBtn.Background = new SolidColorBrush(Colors.Transparent);

                ViewModel.ChangeModeCommand.Execute(null);
            }
        }
    }
}
