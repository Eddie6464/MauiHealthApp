using MentalHealthApp.Services;
using Microsoft.Maui.Controls;

namespace MentalHealthApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Get the database service from DI
            var databaseService = Handler.MauiContext.Services.GetRequiredService<DatabaseService>();

            // Create navigation page with MainPage and inject the database service
            return new Window(new NavigationPage(new MainPage(databaseService)));
        }
    }
}