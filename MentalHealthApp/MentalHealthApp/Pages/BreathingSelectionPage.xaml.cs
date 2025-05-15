using MentalHealthApp.Models;
using MentalHealthApp.Services;

namespace MentalHealthApp
{
    public partial class BreathingSelectionPage : ContentPage
    {
        private readonly DatabaseService _database;
        private readonly ActivityLog _activity;

        public BreathingSelectionPage(DatabaseService database, ActivityLog activity)
        {
            InitializeComponent();
            _database = database;
            _activity = activity;
        }

        private async void OnExerciseClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string selected = button.Text;
                await Navigation.PushAsync(new BreathingExercisePage(_database, _activity, selected));
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}
