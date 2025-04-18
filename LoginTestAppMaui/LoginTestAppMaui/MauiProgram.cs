using CommunityToolkit.Maui;
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
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("JAVATEXT.ttf", "JavaneseRegular");
                });

            builder.Services.AddSingleton<IPreferencesService, PreferencesService>();
            builder.Services.AddSingleton<IPopUpService, PopUpService>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IStringService, StringService>();

            builder.Services.AddTransientWithShellRoute<LoginPage, LoginViewModel>(nameof(LoginPage));
            builder.Services.AddTransientWithShellRoute<MainPage, MainViewModel>(nameof(MainPage));

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
