using LoginTestAppMaui.ViewModels;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace LoginTestAppMaui.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
        UpdateSelectionData(Enumerable.Empty<string>());
    }

    void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateSelectionData(e.CurrentSelection);
    }

    void UpdateSelectionData(IEnumerable<object> currentSelectedItems)
    {
        var current = ToList(currentSelectedItems);
        currentSelectedItemLabel.Text = string.IsNullOrWhiteSpace(current) ? "[none]" : current;
    }
        static string ToList(IEnumerable<object> items)
    {
        if (items == null)
        {
            return string.Empty;
        }

        return items.Aggregate(string.Empty, (sender, obj) => sender + (sender.Length == 0 ? "" : ", ") + ((string)obj));
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (BindingContext is MainViewModel viewModel)
        {
            viewModel.GetCurrentUser();
        }
    }
}