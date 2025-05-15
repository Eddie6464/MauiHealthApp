using MentalHealthApp.Models;
using MentalHealthApp.Services;

namespace MentalHealthApp
{
    public partial class EditJournalEntryPage : ContentPage
    {
        private readonly DatabaseService _database;
        private readonly JournalEntry _entry;

        public EditJournalEntryPage(DatabaseService database, JournalEntry entry)
        {
            InitializeComponent();
            _database = database;
            _entry = entry;

            TitleEntry.Text = _entry.Title;
            ContentEditor.Text = _entry.Content;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleEntry.Text))
            {
                await DisplayAlert("Error", "Title cannot be empty.", "OK");
                return;
            }

            _entry.Title = TitleEntry.Text ?? string.Empty;
            _entry.Content = ContentEditor.Text ?? string.Empty;

            await _database.SaveJournalEntryAsync(_entry);
            await DisplayAlert("Success", "Journal entry updated.", "OK");
            await Navigation.PopAsync();
        }
    }
}
