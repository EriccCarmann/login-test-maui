using LoginTestAppMaui.Services.Abstract;
using System.Diagnostics;

namespace LoginTestAppMaui.Services.Implementation
{
    public class PopUpService : IPopUpService
    {
        public async Task<string> ActionSheetPopUp(string title, string[] options)
        {
            return await Shell.Current.CurrentPage
                .DisplayActionSheet(title, "Cancel", null, options);
        }

        public async Task MessagePopUp(string title, string message)
        {
            await Shell.Current.CurrentPage.DisplayAlert(title, message, "OK");
        }

        public async Task<bool> QuestionPopUp(string title, string content)
        {
            return await Shell.Current.CurrentPage.DisplayAlert(title, content, "Yes", "No");
        }
    }
}
