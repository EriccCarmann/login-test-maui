using LoginTestAppMaui.Services.Abstract;
using LoginTestAppMaui.ViewModels;

namespace LoginTestAppMaui.Views;

public partial class MainPage : ContentPage
{
    private readonly IStringService _stringService;
    private readonly INasaService _nasaService;

    public MainPage(MainViewModel viewModel, IStringService stringService, INasaService nasaService)
    {
        InitializeComponent();

        BindingContext = viewModel;

        _stringService = stringService;
        _nasaService = nasaService;

        UpdateSelectionData(Enumerable.Empty<string>());
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
       
        if (BindingContext is MainViewModel viewModel)
        {
            _nasaService.GetAsteroids();
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