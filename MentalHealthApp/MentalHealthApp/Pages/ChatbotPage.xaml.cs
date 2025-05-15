using MentalHealthApp.Models;
using MentalHealthApp.Services;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;

namespace MentalHealthApp
{
    public partial class ChatBotPage : ContentPage
    {
        private readonly DatabaseService _database;
        private ObservableCollection<ChatMessage> _messages = new ObservableCollection<ChatMessage>();

        public ChatBotPage(DatabaseService database)
        {
            InitializeComponent();
            _database = database;
            LoadChatHistory();
            InitializeBotGreeting();
        }

        private async void LoadChatHistory()
        {
            var history = await _database.GetChatHistoryAsync();
            foreach (var message in history)
            {
                AddMessageToChat(message.UserMessage, false);
                AddMessageToChat(message.BotResponse, true);
            }
        }

        private void InitializeBotGreeting()
        {
            if (_messages.Count == 0)
            {
                AddMessageToChat("Hello! I'm Lumi. How can I help you today?", true);
            }
        }

        private async void AddMessageToChat(string message, bool isBotMessage)
        {
            var chatMessage = new ChatMessage
            {
                UserMessage = isBotMessage ? null : message,
                BotResponse = isBotMessage ? message : null,
                Timestamp = DateTime.Now
            };

            var messageView = CreateMessageView(message, isBotMessage);
            ChatArea.Children.Add(messageView);

            if (!isBotMessage)
            {
                await _database.SaveChatMessageAsync(chatMessage);
            }
           
            await Task.Delay(100);
            await ChatScrollView.ScrollToAsync(ChatArea, ScrollToPosition.End, true);
        }

        private void AddNavigationButtonToChat(string buttonText, Func<Task> onClicked, Color? backgroundColor = null)

        {
            var button = new Button
            {
                Text = buttonText,
                FontSize = 16,
                BackgroundColor = backgroundColor ?? Color.FromArgb("#6B5B95"),
                TextColor = Colors.White,
                CornerRadius = 10,
                Padding = new Thickness(10),
                HorizontalOptions = LayoutOptions.Start
            };

            button.Clicked += async (s, e) => await onClicked();

            ChatArea.Children.Add(button);
        }


        private View CreateMessageView(string message, bool isBotMessage)
        {
            return new Border
            {
                BackgroundColor = isBotMessage ? Color.FromArgb("#E0E0E0") : Color.FromArgb("#6B5B95"),
                StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) },
                Padding = new Thickness(12),
                HorizontalOptions = isBotMessage ? LayoutOptions.Start : LayoutOptions.End,
                Margin = new Thickness(5, 2, 5, 2),
                Content = new Label
                {
                    Text = message,
                    FontSize = 16,
                    TextColor = isBotMessage ? Colors.Black : Colors.White,
                    MaxLines = 10,
                    LineBreakMode = LineBreakMode.WordWrap
                }
            };
        }

        private async void OnHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmotionTrackingPage(_database));
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActivitiesPage(_database));
        }

        private void OnAnxiousClicked(object sender, EventArgs e)
        {
            AddMessageToChat("I'm feeling anxious", false);

            AddMessageToChat("I understand you're feeling anxious. That's completely valid.", true);
            AddMessageToChat("Would you like to try one of these?", true);

            AddNavigationButtonToChat("Breathing Exercise", async () =>
            {
                var activity = new ActivityLog { ActivityType = "Breathing", StartTime = DateTime.Now };
                await _database.StartActivityAsync(activity);
                await Navigation.PushAsync(new BreathingExercisePage(_database, activity, "Box Breathing"));

            }, Color.FromArgb("#88B04B"));

            AddNavigationButtonToChat("Grounding Techniques", async () =>
            {
                await DisplayAlert("5-4-3-2-1 Grounding",
                    "• 5 things you can see\n• 4 things you can touch\n• 3 things you can hear\n• 2 things you can smell\n• 1 thing you can taste",
                    "Done");
            }, Color.FromArgb("#FFA07A"));

            AddNavigationButtonToChat("Journaling", async () =>
            {
                var activity = new ActivityLog { ActivityType = "Journaling", StartTime = DateTime.Now };
                await _database.StartActivityAsync(activity);
                await Navigation.PushAsync(new JournalingPage(_database, activity));
            }, Color.FromArgb("#6B5B95"));
        }


        private void OnSadClicked(object sender, EventArgs e)
        {
            AddMessageToChat("I'm feeling sad", false);

            AddMessageToChat("I'm sorry you're feeling this way. Sadness can feel heavy.", true);
            AddMessageToChat("Here are some things that may help:", true);

            AddNavigationButtonToChat("Journaling", async () =>
            {
                var activity = new ActivityLog { ActivityType = "Journaling", StartTime = DateTime.Now };
                await _database.StartActivityAsync(activity);
                await Navigation.PushAsync(new JournalingPage(_database, activity));
            }, Color.FromArgb("#88B04B"));

            AddNavigationButtonToChat("Comforting Activity", async () =>
            {
                await DisplayAlert("Tip", "Try listening to music, stretching, or cuddling a pet.", "OK");
            }, Color.FromArgb("#FFA07A"));

            AddNavigationButtonToChat("Stretching", async () =>
            {
                var activity = new ActivityLog { ActivityType = "Stretching", StartTime = DateTime.Now };
                await _database.StartActivityAsync(activity);
                await Navigation.PushAsync(new StretchingPage(_database, activity, "Neck & Shoulders"));
            }, Color.FromArgb("#6B5B95"));
        }



        private void OnStressedClicked(object sender, EventArgs e)
        {
            AddMessageToChat("I'm feeling stressed", false);

            AddMessageToChat("Stress can feel overwhelming. Let's try something calming.", true);
            AddMessageToChat("Choose one of the options below:", true);

            AddNavigationButtonToChat("5-4-3-2-1 Grounding", async () =>
            {
                await DisplayAlert("5-4-3-2-1 Grounding",
                    "• 5 things you can see\n• 4 things you can touch\n• 3 things you can hear\n• 2 things you can smell\n• 1 thing you can taste",
                    "Got it");
            }, Color.FromArgb("#88B04B"));

            AddNavigationButtonToChat("Muscle Relaxation", async () =>
            {
                await DisplayAlert("Progressive Muscle Relaxation",
                    "Slowly tense and release each muscle group in your body. Breathe as you go.",
                    "Got it");
            }, Color.FromArgb("#FFA07A"));

            AddNavigationButtonToChat("Stretching", async () =>
            {
                var activity = new ActivityLog { ActivityType = "Stretching", StartTime = DateTime.Now };
                await _database.StartActivityAsync(activity);
                await Navigation.PushAsync(new StretchingPage(_database, activity, "Full Body"));
            }, Color.FromArgb("#6B5B95"));
        }





        private async void OnClearChatClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Clear Chat", "Are you sure you want to delete all chat history?", "Yes", "No");
            if (confirm)
            {
                await _database.ClearChatHistoryAsync();
                ChatArea.Children.Clear(); 
                _messages.Clear();
                InitializeBotGreeting(); 
            }
        }

    }
}