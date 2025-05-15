using MentalHealthApp.Models;
using MentalHealthApp.Services;

namespace MentalHealthApp
{
    public partial class StretchingSelectionPage : ContentPage
    {
        private readonly DatabaseService _database;
        private readonly ActivityLog _activity;

        public StretchingSelectionPage(DatabaseService database, ActivityLog activity)
        {
            InitializeComponent();
            _database = database;
            _activity = activity;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnStretchingClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string selected = button.Text;
                await Navigation.PushAsync(new StretchingPage(_database, _activity, selected));
            }
        }
    }
}
