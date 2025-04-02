using CommunityToolkit.Mvvm.ComponentModel;
using LoginTestAppMaui.Services.Abstract;

namespace LoginTestAppMaui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IPreferencesService _preferences;

        [ObservableProperty]
        private string username;

        public MainViewModel(IPreferencesService preferencesService)
        {
            _preferences = preferencesService;
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
    }
}
