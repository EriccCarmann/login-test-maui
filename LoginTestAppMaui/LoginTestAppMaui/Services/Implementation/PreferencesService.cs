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
        public string GetPreference(string key)
        {
            return Preferences.Get(key, null);
        }

        public void SetStringPreference(string value)
        {
            Preferences.Default.Set("PREF_USER_NAME", value);
        }
    }
}
