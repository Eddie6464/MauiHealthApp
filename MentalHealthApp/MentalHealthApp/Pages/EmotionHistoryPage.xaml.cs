using MentalHealthApp.Models;
using MentalHealthApp.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MentalHealthApp
{
    public partial class EmotionHistoryPage : ContentPage
    {
        private readonly DatabaseService _database;

        public EmotionHistoryPage(DatabaseService database)
        {
            InitializeComponent();
            _database = database;
        }

        // When the page appears, load the emotion records asynchronously
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadEmotionRecords();
        }
        

        private async Task LoadEmotionRecords()
        {
            EmotionList.Children.Clear();
            var records = await _database.GetEmotionRecordsAsync();

            foreach (var record in records)
            {
                
                var layout = new VerticalStackLayout
                {
                    Padding = 10,
                    BackgroundColor = Colors.White,
                    Children =
                    {
                        new Label { Text = "Emotion: " + record.Emotion, FontAttributes = FontAttributes.Bold, TextColor = Colors.Black },
                        new Label { Text = "Activities: " + record.Activities, TextColor = Colors.Black },
                        new Label { Text = "Comments: " + record.Comments, TextColor = Colors.Black },
                        new Label { Text = "Date: " + record.Date.ToString("g"), FontSize = 12, TextColor = Colors.Black },

                        new HorizontalStackLayout
                        {
                            Spacing = 10,
                            Children =
                            {
                                new Button
                                {
                                    Text = "Edit",
                                    BackgroundColor = Colors.LightGray,
                                    Command = new Command(async () => await EditRecord(record))
                                },
                                new Button
                                {
                                    Text = "Delete",
                                    BackgroundColor = Colors.Red,
                                    TextColor = Colors.White,
                                    Command = new Command(async () => await DeleteRecord(record))
                                }
                            }
                        }
                    }
                };

                EmotionList.Children.Add(layout);
            }
        }

        private async Task DeleteRecord(EmotionRecord record)
        {
            bool confirm = await DisplayAlert("Confirm", "Delete this record?", "Yes", "No");
            if (confirm)
            {
                await _database.DeleteEmotionRecordAsync(record);
                await LoadEmotionRecords();
            }
        }

        private async Task EditRecord(EmotionRecord record)
        {
            
            await Navigation.PushAsync(new EmotionTrackingPage(_database, record));
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}