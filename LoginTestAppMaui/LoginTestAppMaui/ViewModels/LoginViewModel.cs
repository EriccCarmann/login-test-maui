using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginTestAppMaui.Services.Abstract;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace LoginTestAppMaui.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        public IRelayCommand LoginCommand { get; }

        [ObservableProperty]
        private string login;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        private readonly IPreferencesService _preferences;

        public LoginViewModel(IPreferencesService preferences)
        {
            LoginCommand = new RelayCommand(OnLoginCommand);
            _preferences = preferences;
        }

        private void OnLoginCommand()
        {
            if (string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                var toast = Toast.Make("Fill all fields!", ToastDuration.Short, 15);

                toast.Show(cancellationTokenSource.Token);
            }
            else
            {
                _preferences.SetStringPreference(login);
                Shell.Current.GoToAsync("MainPage");
            }
        }
    }
}
