using LoginTestAppMaui.Services.Abstract;
using LoginTestAppMaui.Services.Implementation;
using LoginTestAppMaui.ViewModels;
using LoginTestAppMaui.Views;
using Microsoft.Extensions.Logging;

namespace LoginTestAppMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IPreferencesService, PreferencesService>();

            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton<LoginViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
