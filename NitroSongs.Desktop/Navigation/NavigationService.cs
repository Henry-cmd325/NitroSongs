using Microsoft.UI.Xaml.Controls;

namespace NitroSongs.Navigation
{
    public class NavigationService : INavigationService
    {
        private Frame? _frame;

        public void Initialize(Frame frame)
        {
            _frame = frame;
        }

        public void NavigateTo<TPage>(object? parameters = default) where TPage : Page
        {
            if (_frame == null) return;

            if (parameters != default)
                _frame.Navigate(typeof(TPage), parameters);
            else
                _frame.Navigate(typeof(TPage));
        }

        public void GoBack()
        {
            if (_frame == null) return;

            if (_frame.CanGoBack)
                _frame.GoBack();
        }
    }
}
