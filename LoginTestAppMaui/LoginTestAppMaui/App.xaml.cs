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