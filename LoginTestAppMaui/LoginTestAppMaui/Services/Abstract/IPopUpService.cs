namespace LoginTestAppMaui.Services.Abstract
{
    public interface IPopUpService
    {
        Task ErrorMessagePopUp(string error);
        void QuestionPopUp();
        void ActionSheetPopUp();
    }
}
