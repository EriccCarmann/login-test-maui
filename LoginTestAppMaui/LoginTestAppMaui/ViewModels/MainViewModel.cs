﻿using CommunityToolkit.Mvvm.ComponentModel;
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

        public IRelayCommand CallMessage { get; set; }
        public IAsyncRelayCommand CallQuestionMessage { get; set; }
        public IAsyncRelayCommand CallOptionsMessage { get; set; }

        public MainViewModel(IPreferencesService preferencesService, IPopUpService popUpService)
        {
            _preferences = preferencesService;
            _popUpService = popUpService;

            CallMessage = new RelayCommand(OnCallMessage);
            CallQuestionMessage = new AsyncRelayCommand(OnCallQuestionMessage);
            CallOptionsMessage = new AsyncRelayCommand(OnCallOptionsMessage);

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

        private void OnCallMessage()
        {
            _popUpService.MessagePopUp("Error", "Some text to fill the box.");
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
