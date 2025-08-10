using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NitroSongs.Common.Dtos;
using NitroSongs.Services.Songs;
using NitroSongs.UserControls.Pager.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Modules.Songs.ViewModels
{
    public partial class SongsViewModel : ObservableObject
    {
        private readonly ISongService _service;

        public ObservableCollection<SongDto> Songs { get; set; } = [];

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private int pageIndex = 1;

        [ObservableProperty]
        private int totalPages = 1;
        public SongsViewModel(ISongService service)
        {
            _service = service;
        }

        [RelayCommand]
        public async Task LoadSongsAsync(PagerParametersDto? datos = default)
        {
            try
            {
                IsLoading = true;

                datos ??= new PagerParametersDto { Page = 1, Size = 10 };

                var songs = await _service.GetSongs(datos.Page, datos.Size);

                Songs.Clear();

                foreach (var song in songs.Items)
                {
                    Songs.Add(song);
                }    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
