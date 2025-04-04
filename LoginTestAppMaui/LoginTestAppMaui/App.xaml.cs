﻿using LoginTestAppMaui.ViewModels;
using LoginTestAppMaui.Views;

namespace LoginTestAppMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}