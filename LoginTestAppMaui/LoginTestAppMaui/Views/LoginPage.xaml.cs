using LoginTestAppMaui.ViewModels;

namespace LoginTestAppMaui.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();

		BindingContext = loginViewModel;
	}
}