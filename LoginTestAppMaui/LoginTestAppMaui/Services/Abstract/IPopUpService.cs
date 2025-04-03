namespace LoginTestAppMaui.Services.Abstract
{
    public interface IPopUpService
    {
        Task MessagePopUp(string title, string message);
        Task<bool> QuestionPopUp(string title, string content);
        Task<string> ActionSheetPopUp(string title, string[] options);
    }
}
