using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Modules.Songs.ViewModels
{
    public partial class SongEditViewModel : ObservableObject
    {
        [ObservableProperty]
        private string btnText = "Modo Texto";

        [ObservableProperty]
        private bool isVisualMode = true;

        public bool IsTextMode => !IsVisualMode;

        [RelayCommand]
        public void SwitchMode() 
        {
            IsVisualMode = !IsVisualMode;

            if (IsVisualMode)
                BtnText = "Modo Texto";
            else
                BtnText = "Modo Visual";
        } 
    }
}
