using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginTestAppMaui.Services.Abstract;
using LoginTestAppMaui.Views;

namespace LoginTestAppMaui.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        public IRelayCommand LoginCommand { get; }

        [ObservableProperty]
        private string login;

        private readonly IPreferencesService _preferences;

        public LoginViewModel(IPreferencesService preferences)
        {
            LoginCommand = new RelayCommand(OnLoginCommand);
            _preferences = preferences;
        }

        private void OnLoginCommand()
        {
            _preferences.SetStringPreference(login);

            Routing.RegisterRoute("MainPage", typeof(MainPage));

            if (true)
            {
                Shell.Current.GoToAsync("MainPage");
            }
        }
    }
}
