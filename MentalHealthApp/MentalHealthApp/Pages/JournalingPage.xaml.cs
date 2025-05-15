using MentalHealthApp.Models;
using MentalHealthApp.Services;

namespace MentalHealthApp
{
    public partial class JournalingPage : ContentPage
    {
        private readonly DatabaseService _database;
        private readonly ActivityLog _currentActivity;

        public JournalingPage(DatabaseService database, ActivityLog currentActivity)
        {
            InitializeComponent();
            _database = database;
            _currentActivity = currentActivity;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var journalEntry = new JournalEntry
            {
                Title = $"Journal Entry {DateTime.Now:g}",
                Content = JournalEditor.Text ?? string.Empty,
                CreatedDate = DateTime.Now
            };

            await _database.SaveJournalEntryAsync(journalEntry);

            _currentActivity.EndTime = DateTime.Now;
            _currentActivity.Notes = journalEntry.Title;
            await _database.EndActivityAsync(_currentActivity);

            await DisplayAlert("Success", "Your journal entry has been saved.", "OK");

            JournalEditor.Text = string.Empty;
        }

        private async void OnHistoryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JournalingHistoryPage(_database));
        }

        private async void OnBackToActivitiesClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}
