namespace LoginTestAppMaui.Services.Abstract
{
    public interface IPreferencesService
    {
        string GetCurrentUserPreference();
        void SetStringPreference(string value);

        void RemoveCurrentUserPreference();
    }
}
