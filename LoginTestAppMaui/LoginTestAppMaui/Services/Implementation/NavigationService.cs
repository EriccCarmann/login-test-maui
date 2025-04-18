using LoginTestAppMaui.Services.Abstract;

namespace LoginTestAppMaui.Services.Implementation
{
    class NavigationService : INavigationService
    {
        public void GoBack()
        {
            Shell.Current.GoToAsync("..");
        }
    }
}
