using LoginTestAppMaui.Services.Abstract;
using LoginTestAppMaui.ViewModels;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace LoginTestAppMaui.Views;

public partial class MainPage : ContentPage
{
    IStringService _stringService;

    public MainPage(MainViewModel viewModel, IStringService stringService)
    {
        InitializeComponent();
        _stringService = stringService;

        BindingContext = viewModel;
        UpdateSelectionData(Enumerable.Empty<string>());
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (BindingContext is MainViewModel viewModel)
        {
            viewModel.GetCurrentUser();
        }
    }

    void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateSelectionData(e.CurrentSelection);
    }

    void UpdateSelectionData(IEnumerable<object> currentSelectedItems)
    {
        var current = _stringService.ToList(currentSelectedItems);
        currentSelectedItemLabel.Text = _stringService.CheckStringNullOrWhiteSpace(current);
    }
}