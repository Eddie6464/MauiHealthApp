using MentalHealthApp.Models;
using MentalHealthApp.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel;
using System;

namespace MentalHealthApp
{
    public partial class EmotionTrackingPage : ContentPage
    {
        private readonly DatabaseService _database;
        private EmotionRecord _editingRecord;

        public EmotionTrackingPage(DatabaseService database, EmotionRecord? existingRecord = null)
        {
            InitializeComponent();
            _database = database ?? throw new ArgumentNullException(nameof(database));

            _editingRecord = existingRecord ?? new EmotionRecord();

            emotionPicker.SelectedItem = _editingRecord.Emotion;
            activitiesEditor.Text = _editingRecord.Activities;
            commentsEditor.Text = _editingRecord.Comments;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            try
            {
                var selectedEmotion = emotionPicker?.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedEmotion))
                {
                    await ShowAlert("Error", "Please select an emotion");
                    return;
                }

                _editingRecord.Emotion = selectedEmotion;
                _editingRecord.Activities = activitiesEditor?.Text ?? string.Empty;
                _editingRecord.Comments = commentsEditor?.Text ?? string.Empty;
                _editingRecord.Date = DateTime.Now;

                await _database.SaveEmotionRecordAsync(_editingRecord);

                await ShowAlert("Success", "Your entry has been saved");

                emotionPicker.SelectedIndex = -1;
                activitiesEditor.Text = string.Empty;
                commentsEditor.Text = string.Empty;

            }
            catch (Exception ex)
            {
                await ShowAlert("Error", $"Failed to save: {ex.Message}");
            }
        }


        private async Task ShowAlert(string title, string message, Func<Task>? onClose = null)
        {
            if (MainThread.IsMainThread)
            {
                await DisplayAlert(title, message, "OK");
                if (onClose != null) await onClose();
            }
            else
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await this.DisplayAlert(title, message, "OK");
                    if (onClose != null) await onClose();
                });
            }
        }

        private async void OnViewHistoryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmotionHistoryPage(_database));
        }

        private async void OnBackToActivitiesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActivitiesPage(_database));

        }

        private async void OnHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();

        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChatBotPage(_database));
        }

    }
}
