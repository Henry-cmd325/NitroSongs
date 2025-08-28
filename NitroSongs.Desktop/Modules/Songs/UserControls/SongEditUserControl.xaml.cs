using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using NitroSongs.Modules.Songs.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NitroSongs.Modules.Songs.UserControls;

public sealed partial class SongEditUserControl : UserControl
{
    public SongEditViewModel ViewModel;
    public SongEditUserControl()
    {
        InitializeComponent();
        ViewModel = App.AppHost.Services.GetRequiredService<SongEditViewModel>();
        DataContext = ViewModel;
    }

    public string Lyrics
    {
        get => (string)GetValue(LyricsProperty);
        set 
        {
            SetValue(LyricsProperty, value);
            ViewModel.LoadTokens(value);
        }
    }

    public static readonly DependencyProperty LyricsProperty =
        DependencyProperty.Register(nameof(Lyrics), typeof(string), typeof(SongEditUserControl), new PropertyMetadata(""));

    // Al iniciar el drag desde un chip de acorde
    private void Chord_DragStarting(UIElement sender, DragStartingEventArgs args)
    {
        //if (sender is Border b && b.DataContext is string chord)
        //{
        //    args.Data.SetText(chord);
        //    args.Data.RequestedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;

        //    // Visual opcional:
        //    args.DragUI.SetContentFromDataPackage();
        //}
    }

    // Mientras arrastras sobre un token (para permitir el drop)
    private void Token_DragOver(object sender, DragEventArgs e)
    {
        //if (e.DataView.Contains(Windows.ApplicationModel.DataTransfer.StandardDataFormats.Text))
        //{
        //    e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
        //}
        //e.Handled = true;
    }

    // Sueltas el acorde sobre un token
    private async void Token_Drop(object sender, DragEventArgs e)
    {
        //if (sender is FrameworkElement fe && fe.DataContext is LyricToken token)
        //{
        //    if (e.DataView.Contains(Windows.ApplicationModel.DataTransfer.StandardDataFormats.Text))
        //    {
        //        var chord = await e.DataView.GetTextAsync();
        //        token.Chord = chord?.Trim();
        //        token.HasChord = !string.IsNullOrEmpty(token.Chord);
        //    }
        //}
        //e.Handled = true;
    }
}
