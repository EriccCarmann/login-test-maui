using LoginTestAppMaui.Views;

namespace LoginTestAppMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Routing.RegisterRoute("MainPage", typeof(MainPage));

            if (true) 
            {
                Shell.Current.GoToAsync("MainPage");
            }
        }
    }
}
 