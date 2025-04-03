using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginTestAppMaui.Services.Abstract;

namespace LoginTestAppMaui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IPreferencesService _preferences;
        private readonly IPopUpService _popUpService;

        [ObservableProperty]
        private string username;

        private IRelayCommand CallErrorMessage {  get; }

        public MainViewModel(IPreferencesService preferencesService, IPopUpService popUpService)
        {
            _preferences = preferencesService;
            _popUpService = popUpService;

            CallErrorMessage = new RelayCommand(OnCallErrorMessage);

            GetCurrentUser();
        }

        public void GetCurrentUser()
        {
            username = _preferences.GetCurrentUserPreference();
        }

        public void ClearCurrentUser()
        {
            _preferences.RemoveCurrentUserPreference();
        }

        public void OnCallErrorMessage()
        {
            _popUpService.ErrorMessagePopUp("error");
        }
    }
}
