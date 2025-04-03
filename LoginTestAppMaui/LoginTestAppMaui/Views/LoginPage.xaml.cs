using LoginTestAppMaui.Services.Abstract;
using LoginTestAppMaui.ViewModels;

namespace LoginTestAppMaui.Views;

public partial class LoginPage : ContentPage
{
    private readonly IPreferencesService _preferencesService;

	public LoginPage(LoginViewModel loginViewModel, IPreferencesService preferencesService)
	{
		InitializeComponent();

		BindingContext = loginViewModel;

        _preferencesService = preferencesService;

        if (!string.IsNullOrEmpty(_preferencesService.GetCurrentUserPreference()))
        {
            Shell.Current.GoToAsync("MainPage");
        }
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        _preferencesService.RemoveCurrentUserPreference();
    }
}