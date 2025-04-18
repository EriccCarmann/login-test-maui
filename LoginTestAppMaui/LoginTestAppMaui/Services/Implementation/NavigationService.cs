using LoginTestAppMaui.Services.Abstract;

namespace LoginTestAppMaui.Services.Implementation
{
    public class NavigationService : INavigationService
    {
        public void GoBack()
        {
            Shell.Current.GoToAsync("..");
        }
    }
}
