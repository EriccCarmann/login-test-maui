using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginTestAppMaui.Services.Abstract;

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
        private readonly INavigationService _navigationService;

        public LoginViewModel(IPreferencesService preferences,
                              INavigationService navigationService)
        {
            LoginCommand = new RelayCommand(OnLoginCommand);
            CloseErrorMessage = new RelayCommand(OnCloseErrorMessage);
            _preferences = preferences;
            _navigationService = navigationService;

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
                _navigationService.GoToAppShell();
            }
        }

        private void OnCloseErrorMessage()
        {
            ErrorMessageVisibility = false;
        }
    }
}
