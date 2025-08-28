using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using NitroSongs.Services.Songs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Modules.Songs.ViewModels
{
    public class LyricToken : DependencyObject
    {
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(LyricToken), new PropertyMetadata(""));

        public string Chord
        {
            get => (string)GetValue(ChordProperty);
            set => SetValue(ChordProperty, value);
        }
        public static readonly DependencyProperty ChordProperty =
            DependencyProperty.Register(nameof(Chord), typeof(string), typeof(LyricToken), new PropertyMetadata(""));

        public bool HasChord
        {
            get => (bool)GetValue(HasChordProperty);
            set => SetValue(HasChordProperty, value);
        }
        public static readonly DependencyProperty HasChordProperty =
            DependencyProperty.Register(nameof(HasChord), typeof(bool), typeof(LyricToken), new PropertyMetadata(false));
    }
    public partial class SongEditViewModel : ObservableObject
    {
        [ObservableProperty]
        private string btnText = "Modo Texto";

        [ObservableProperty]
        private bool isVisualMode = true;

        [ObservableProperty]
        private bool isTextMode = false;

        public ObservableCollection<LyricToken> LyricTokens { get; } = [];

        [RelayCommand]
        public void LoadTokens(string Lyrics)
        {
            LyricTokens.Clear();
            LyricTokens.Add(new LyricToken { Text = "h", Chord = "", HasChord = false });
            LyricTokens.Add(new LyricToken { Text = "o", Chord = "", HasChord = false });
            LyricTokens.Add(new LyricToken { Text = "l", Chord = "", HasChord = false });
            LyricTokens.Add(new LyricToken { Text = "a", Chord = "", HasChord = false });
            LyricTokens.Add(new LyricToken { Text = "e", Chord = "D", HasChord = true });
            LyricTokens.Add(new LyricToken { Text = "s", Chord = "C", HasChord = true });
            LyricTokens.Add(new LyricToken { Text = "u", Chord = "", HasChord = false });
            LyricTokens.Add(new LyricToken { Text = "n", Chord = "", HasChord = false });
            LyricTokens.Add(new LyricToken { Text = "a", Chord = "", HasChord = false });
        }

        [RelayCommand]
        public void SwitchMode() 
        {
            IsVisualMode = !IsVisualMode;
            IsTextMode = !IsTextMode;

            if (IsVisualMode)
                BtnText = "Modo Texto";
            else
                BtnText = "Modo Visual";
        } 
    }
}
