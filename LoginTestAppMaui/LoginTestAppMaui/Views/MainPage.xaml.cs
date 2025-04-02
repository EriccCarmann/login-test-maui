using LoginTestAppMaui.ViewModels;

namespace LoginTestAppMaui.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (BindingContext is MainViewModel viewModel)
        {
            viewModel.GetCurrentUser();
        }
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        var page = Navigation.NavigationStack.LastOrDefault();
        Navigation.RemovePage(page);
        base.OnNavigatedFrom(args);
    }
}