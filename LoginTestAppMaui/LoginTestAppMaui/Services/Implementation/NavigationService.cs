using LoginTestAppMaui.Services.Abstract;
using LoginTestAppMaui.Views;

namespace LoginTestAppMaui.Services.Implementation
{
    public class NavigationService : INavigationService
    {
        public void GoBack()
        {
            Shell.Current.GoToAsync("..");

        }

        public void GoToAppShell()
        {
            Application.Current.MainPage = new AppShell();
        }

        public void GoToLogin()
        {
            Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }
    }
}
