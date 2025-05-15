using MentalHealthApp.Models;
using MentalHealthApp.Services;
using System.Collections.ObjectModel;

namespace MentalHealthApp
{
    public partial class JournalingHistoryPage : ContentPage
    {
        private readonly DatabaseService _database;
        private ObservableCollection<JournalEntry> _entries = new();

        public JournalingHistoryPage(DatabaseService database)
        {
            InitializeComponent();
            _database = database;
            LoadEntries();
        }

        private async void LoadEntries()
        {
            var entries = await _database.GetJournalEntriesAsync();
            _entries = new ObservableCollection<JournalEntry>(entries);
            JournalListView.ItemsSource = _entries;
        }

        private async void OnEntrySelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is JournalEntry selected)
            {
                await Navigation.PushAsync(new EditJournalEntryPage(_database, selected));
                JournalListView.SelectedItem = null; 
            }
        }
        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is JournalEntry entry)
            {
                bool confirm = await DisplayAlert("Delete Entry", "Are you sure you want to delete this entry?", "Yes", "No");
                if (confirm)
                {
                    await _database.DeleteJournalEntryAsync(entry);
                    _entries.Remove(entry);
                }
            }
        }

    }
}
