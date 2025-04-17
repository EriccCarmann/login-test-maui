using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginTestAppMaui.Services.Abstract;
using LoginTestAppMaui.Models;
using System.Collections.ObjectModel;

namespace LoginTestAppMaui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<Genre> MusicGenres { get;  } = new();

        public ObservableCollection<string> SelectedGenres { get; } = new ObservableCollection<string>();

        private readonly IPreferencesService _preferences;
        private readonly IPopUpService _popUpService;

        [ObservableProperty]
        private string username;

        public IRelayCommand CallMessage { get; set; }
        public IRelayCommand GoBack { get; set; }
        public IAsyncRelayCommand CallQuestionMessage { get; set; }
        public IAsyncRelayCommand CallOptionsMessage { get; set; }

        public MainViewModel(IPreferencesService preferencesService, IPopUpService popUpService)
        {
            _preferences = preferencesService;
            _popUpService = popUpService;

            CallMessage = new RelayCommand(OnCallMessage);
            GoBack = new RelayCommand(OnGoBack);
            CallQuestionMessage = new AsyncRelayCommand(OnCallQuestionMessage);
            CallOptionsMessage = new AsyncRelayCommand(OnCallOptionsMessage);
            GetCurrentUser();

            Collection<Genre> newMusicGenres = new Collection<Genre>
            {
                new Genre{ GenreName = "Metal"},
                new Genre{ GenreName = "Rock"},
                new Genre{ GenreName = "Jazz"},
                new Genre{ GenreName = "Rap"},
                new Genre{ GenreName = "Pop"}
            };

            foreach (var item in newMusicGenres)
            {
                MusicGenres.Add(item);
            }
        }

        public void GetCurrentUser()
        {
            username = _preferences.GetCurrentUserPreference();
        }

        public void ClearCurrentUser()
        {
            _preferences.RemoveCurrentUserPreference();
        }

        private void OnCallMessage()
        {
            _popUpService.MessagePopUp("Error", "Some text to fill the box.");
        }

        private void OnGoBack()
        {
            Shell.Current.GoToAsync("..");
        }

        private async Task OnCallQuestionMessage()
        {
            bool result = await _popUpService.QuestionPopUp("Question", "This is a question message. Click yes or no.");

            if (result == true)
            {
                await _popUpService.MessagePopUp("Seccess", "True");
            }
            else
            {
                await _popUpService.MessagePopUp("Failure", "False");
            }
        }

        private async Task OnCallOptionsMessage()
        {
            string[] options = new string[] { "Option 1", "Option 2", "Option 3" };

            string result = await _popUpService.ActionSheetPopUp("Options", options);

            await _popUpService.MessagePopUp("Chosen option", result);
        }
    }
}
