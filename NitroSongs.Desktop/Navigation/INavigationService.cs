using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Navigation
{
    public interface INavigationService
    {
        void NavigateTo<TPage>(object? parameters = default) where TPage : Page;

        void Initialize(Frame frame);
        void GoBack();
    }
}
