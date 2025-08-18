using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using NitroSongs.Common.Dtos;
using NitroSongs.Modules.Songs.Views;
using NitroSongs.Navigation;
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
        private readonly INavigationService _navigation;
        public ObservableCollection<SongDto> Songs { get; set; } = [];

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private int pageNumber;

        [ObservableProperty]
        private int totalPages;
        public SongsViewModel(ISongService service, INavigationService navigation)
        {
            _service = service;
            _navigation = navigation;
        }

        [RelayCommand]
        public async Task LoadSongsAsync(PagerParametersDto? datos = default)
        {
            try
            {
                IsLoading = true;

                datos ??= new PagerParametersDto { Page = 1, Size = 10 };

                var songs = await _service.GetSongs(datos.Page, datos.Size);
                PageNumber = songs.PageNumber;
                TotalPages = songs.TotalPages;
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

        [RelayCommand]
        public void SongClicked(SongDto clickedSong) 
        {
            if (clickedSong is null) return;
            
            _navigation.NavigateTo<SongViewerPage>(clickedSong);
        }
    }
}
