using CommunityToolkit.Mvvm.ComponentModel;
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
    public class EditSongViewModel : ObservableObject
    {
        private readonly ISongService _service;
        private readonly INavigationService _navigation;

        private SongMode Mode;

        public EditSongViewModel(ISongService service, INavigationService navigation)
        {
            _service = service;
        }
    }
}
