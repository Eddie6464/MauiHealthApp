using Microsoft.Maui.Controls;
using MentalHealthApp.Services;

namespace MentalHealthApp
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _database;

        public MainPage(DatabaseService database)
        {
            InitializeComponent();
            _database = database;
        }

        private async void OnChatBotClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChatBotPage(_database));
        }

        private async void OnActivitiesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActivitiesPage(_database));
        }

        private async void OnEmotionalTrackingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmotionTrackingPage(_database));
        }
    }
}