using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using NitroSongs.Common;
using NitroSongs.Common.Dtos;
using NitroSongs.Modules.Songs.ViewModels;
using NitroSongs.UserControls.Pager.Dtos;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NitroSongs.Modules.Songs.Views
{
    public sealed partial class SongsPage
    {
        public SongsViewModel ViewModel { get; }
        public SongsPage()
        {
            InitializeComponent();

            ViewModel = App.AppHost.Services.GetRequiredService<SongsViewModel>();
            DataContext = ViewModel;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (ViewModel.Songs.Count == 0)
            {
                await ViewModel.LoadSongsCommand.ExecuteAsync(null);
            }
        }

        private async void Pager_PageChanged(object sender, PagerParametersDto parameters)
        {
            await ViewModel.LoadSongsCommand.ExecuteAsync(parameters);
        }

        private void SongsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is SongDto song)
                ViewModel.SongClickedCommand.Execute(song);
        }
    }
}
