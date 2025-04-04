﻿using LoginTestAppMaui.ViewModels;

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
}