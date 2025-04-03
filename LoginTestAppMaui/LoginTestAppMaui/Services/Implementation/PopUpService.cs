using LoginTestAppMaui.Services.Abstract;

namespace LoginTestAppMaui.Services.Implementation
{
    public class PopUpService : IPopUpService
    {
        public void ActionSheetPopUp()
        {
            throw new NotImplementedException();
        }

        public async Task ErrorMessagePopUp(string error)
        {
            await Shell.Current.CurrentPage.DisplayAlert("Error", error, "OK");
        }

        public void QuestionPopUp()
        {
            throw new NotImplementedException();
        }
    }
}
