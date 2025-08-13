using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using NitroSongs.UserControls.Pager.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NitroSongs.UserControls.Pager
{
    public sealed partial class PagerControl : UserControl
    {
        public PagerControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public int PageNumber
        {
            get => (int)GetValue(PageNumberProperty);
            set => SetValue(PageNumberProperty, value);
        }

        public static readonly DependencyProperty PageNumberProperty =
            DependencyProperty.Register(nameof(PageNumber), typeof(int), typeof(PagerControl), new PropertyMetadata(1));

        public int TotalPages
        {
            get => (int)GetValue(TotalPagesProperty);
            set => SetValue(TotalPagesProperty, value);
        }

        public static readonly DependencyProperty TotalPagesProperty =
            DependencyProperty.Register(nameof(TotalPages), typeof(int), typeof(PagerControl), new PropertyMetadata(1));

        public event EventHandler<PagerParametersDto>? PageChanged;

        private void FirstPage_Click(object sender, RoutedEventArgs e) => ChangePage(1);
        private void PrevPage_Click(object sender, RoutedEventArgs e) => ChangePage(Math.Max(1, PageNumber - 1));
        private void NextPage_Click(object sender, RoutedEventArgs e) => ChangePage(Math.Min(TotalPages, PageNumber + 1));
        private void LastPage_Click(object sender, RoutedEventArgs e) => ChangePage(TotalPages);

        private void ChangePage(int newPage)
        {
            if (newPage != PageNumber)
            {
                PageNumber = newPage;

                string size = "10";
                if (ComboSize.SelectedItem is ComboBoxItem item)
                {
                    size = item.Content?.ToString();
                }
                PageChanged?.Invoke(this, new PagerParametersDto() { Page = newPage, Size = Convert.ToInt16(size) });
            }
        }

        private void ComboSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string size = "10";
            if (ComboSize.SelectedItem is ComboBoxItem item)
            {
                size = item.Content?.ToString();
            }

            PageChanged?.Invoke(this, new PagerParametersDto() { Page = PageNumber, Size = Convert.ToInt16(size) });
        }
    }
}
