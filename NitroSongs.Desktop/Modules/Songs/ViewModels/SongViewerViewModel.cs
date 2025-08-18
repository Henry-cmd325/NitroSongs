using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NitroSongs.Navigation;
using NitroSongs.Services.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Modules.Songs.ViewModels
{
    public enum SongMode { Creating, Editing, Viewing }
    public partial class SongViewerViewModel : ObservableObject
    {
        private readonly ISongService _service;
        private readonly INavigationService _navigation;

        private SongMode Mode;

        [ObservableProperty]
        private string lyrics = "";

        [ObservableProperty]
        private bool isViewMode = true;

        [ObservableProperty]
        private bool isEditMode = false;

        public SongViewerViewModel(ISongService service, INavigationService navigation)
        {
            _service = service;
            _navigation = navigation;
        }

        [RelayCommand]
        public void ChangeMode()
        {
            IsViewMode = !IsViewMode;
            IsEditMode = !IsEditMode;
        }
    }
}
