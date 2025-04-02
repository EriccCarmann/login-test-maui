using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginTestAppMaui.Services.Abstract;

namespace LoginTestAppMaui.Services.Implementation
{
    public class PreferencesService : IPreferencesService
    {
        public string GetCurrentUserPreference()
        {
            return Preferences.Get("PREF_USER_NAME", null);
        }

        public void RemoveCurrentUserPreference()
        {
            Preferences.Remove("PREF_USER_NAME");
        }

        public void SetStringPreference(string value)
        {
            Preferences.Set("PREF_USER_NAME", value);
        }
    }
}
