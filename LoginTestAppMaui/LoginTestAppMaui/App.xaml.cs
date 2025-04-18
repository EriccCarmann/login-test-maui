using LoginTestAppMaui.Services.Abstract;
using LoginTestAppMaui.ViewModels;
using LoginTestAppMaui.Views;

namespace LoginTestAppMaui
{
    public partial class App : Application
    {
        public App(LoginPage loginPage, IPreferencesService preferencesService)
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

            if (string.IsNullOrEmpty(preferencesService.GetCurrentUserPreference()))
            {
                MainPage = loginPage;
            }
            else
            {
                MainPage = new AppShell();
            }
        }
    }
}