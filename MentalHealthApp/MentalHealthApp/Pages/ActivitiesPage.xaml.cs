using Microsoft.Maui.Controls;
using MentalHealthApp.Models;
using MentalHealthApp.Services;

namespace MentalHealthApp
{
    public partial class ActivitiesPage : ContentPage
    {
        private readonly DatabaseService _database;
        private ActivityLog _currentActivity;

        public ActivitiesPage(DatabaseService database)
        {
            InitializeComponent();
            _database = database;
        }

        private async void OnHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChatBotPage(_database));
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmotionTrackingPage(_database));
        }

        private async void OnBreathingExerciseClicked(object sender, EventArgs e)
        {
            _currentActivity = new ActivityLog
            {
                ActivityType = "Breathing",
                StartTime = DateTime.Now
            };
            await _database.StartActivityAsync(_currentActivity);

            await Navigation.PushAsync(new BreathingSelectionPage(_database, _currentActivity));
        }


        private async void OnJournalingClicked(object sender, EventArgs e)
        {
            _currentActivity = new ActivityLog
            {
                ActivityType = "Journaling",
                StartTime = DateTime.Now
            };
            await _database.StartActivityAsync(_currentActivity);

            await Navigation.PushAsync(new JournalingPage(_database, _currentActivity));
        }

        private async void OnStretchingClicked(object sender, EventArgs e)
        {
            _currentActivity = new ActivityLog
            {
                ActivityType = "Stretching",
                StartTime = DateTime.Now
            };
            await _database.StartActivityAsync(_currentActivity);

            await Navigation.PushAsync(new StretchingSelectionPage(_database, _currentActivity));
        }
    }
}