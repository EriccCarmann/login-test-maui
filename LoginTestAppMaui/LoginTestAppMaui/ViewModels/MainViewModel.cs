using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginTestAppMaui.Services.Abstract;
using System.Collections.ObjectModel;

namespace LoginTestAppMaui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<string> MusicGenres { get; } = new ObservableCollection<string>
        {
            "Metal", "Rock", "Jazz", "Rap", "Pop"
        };

        public ObservableCollection<string> SelectedGenres = new ObservableCollection<string>();

        private readonly IPreferencesService _preferences;
        private readonly IPopUpService _popUpService;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string selectedGenre;
        
        [ObservableProperty]
        private string selectedGenresDisplay = "No genres selected";

        public IRelayCommand CallMessage { get; set; }
        public IRelayCommand GoBack { get; set; }
        public IRelayCommand<SelectionChangedEventArgs> SelectionChangedCommand { get; }
        public IAsyncRelayCommand CallQuestionMessage { get; set; }
        public IAsyncRelayCommand CallOptionsMessage { get; set; }

        public MainViewModel(IPreferencesService preferencesService, IPopUpService popUpService)
        {
            _preferences = preferencesService;
            _popUpService = popUpService;

            CallMessage = new RelayCommand(OnCallMessage);
            GoBack = new RelayCommand(OnGoBack);

            SelectionChangedCommand = new RelayCommand<SelectionChangedEventArgs>(OnSelectionChanged);

            CallQuestionMessage = new AsyncRelayCommand(OnCallQuestionMessage);
            CallOptionsMessage = new AsyncRelayCommand(OnCallOptionsMessage);
            GetCurrentUser();
        }
        private void OnSelectionChanged(SelectionChangedEventArgs args)
        {
            // args.CurrentSelection is an IList of the selected items
            var current = args?.CurrentSelection;
            if (current == null)
            {
                SelectedGenresDisplay = Constants.NoGenres;
                return;
            }

            // Safe to cast now
            var selected = current.Cast<string>().ToList();
            SelectedGenresDisplay = string.Join(", ", selected);
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
            _popUpService.MessagePopUp("Error", Constants.SampleText);
        }

        private void OnGoBack()
        {
            Shell.Current.GoToAsync("..");
        }

        private async Task OnCallQuestionMessage()
        {
            bool result = await _popUpService.QuestionPopUp("Question", Constants.QuestionText);

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
