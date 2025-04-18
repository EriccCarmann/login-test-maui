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

        [ObservableProperty]
        private bool errorMessageVisibility;
        
        [ObservableProperty]
        private string errorMessageText;

        public IRelayCommand CloseErrorMessage { get; }

        private readonly IPreferencesService _preferences;

        public LoginViewModel(IPreferencesService preferences)
        {
            LoginCommand = new RelayCommand(OnLoginCommand);
            CloseErrorMessage = new RelayCommand(OnCloseErrorMessage);
            _preferences = preferences;

            ErrorMessageVisibility = false;
        }

        private void OnLoginCommand()
        {
            if (string.IsNullOrEmpty(Login) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password))
            {
                ErrorMessageVisibility = true;
                ErrorMessageText = Constants.EmptyFieldsErrorMessage;
                
            }
            else if (!Login.Equals("Alex"))
            {
                ErrorMessageVisibility = true;
                ErrorMessageText = Constants.MatchErrorMessage;
            }
            else
            {
                ErrorMessageVisibility = false;
                _preferences.SetStringPreference(Login);
                Shell.Current.GoToAsync("MainPage");
            }
        }

        private void OnCloseErrorMessage()
        {
            ErrorMessageVisibility = false;
        }
    }
}
