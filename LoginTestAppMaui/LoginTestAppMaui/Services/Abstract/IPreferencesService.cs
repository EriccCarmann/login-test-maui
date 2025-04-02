namespace LoginTestAppMaui.Services.Abstract
{
    public interface IPreferencesService
    {
        string GetPreference(string key);
        void SetStringPreference(string value);
    }
}
