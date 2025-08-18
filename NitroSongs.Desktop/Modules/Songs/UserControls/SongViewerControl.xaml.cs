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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NitroSongs.Modules.Songs.UserControls;

public sealed partial class SongViewerControl : UserControl
{
    public SongViewerControl()
    {
        InitializeComponent();
        DataContext = this;
    }

    public string Lyrics
    {
        get => (string)GetValue(LyricsProperty);
        set => SetValue(LyricsProperty, value);
    }

    public static readonly DependencyProperty LyricsProperty =
        DependencyProperty.Register(nameof(Lyrics), typeof(string), typeof(SongViewerControl), new PropertyMetadata(""));
}
