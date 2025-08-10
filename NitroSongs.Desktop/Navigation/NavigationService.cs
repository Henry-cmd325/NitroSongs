using Microsoft.UI.Xaml.Controls;

namespace NitroSongs.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly Frame _frame;

        public NavigationService(Frame frame)
        {
            _frame = frame;
        }

        public void NavigateTo<TPage>() where TPage : Page
        {
            _frame.Navigate(typeof(TPage));
        }

        public void GoBack()
        {
            if (_frame.CanGoBack)
                _frame.GoBack();
        }
    }
}
