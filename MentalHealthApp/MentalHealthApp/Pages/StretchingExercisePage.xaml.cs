using MentalHealthApp.Models;
using MentalHealthApp.Services;

namespace MentalHealthApp
{
    public partial class StretchingPage : ContentPage
    {
        private readonly DatabaseService _database;
        private readonly ActivityLog _currentActivity;
        private readonly string _routineName;

        public StretchingPage(DatabaseService database, ActivityLog currentActivity, string routineName)
        {
            InitializeComponent();
            _database = database;
            _currentActivity = currentActivity;
            _routineName = routineName;

            RoutineNameLabel.Text = _routineName;
            RoutineDetailsLabel.Text = GetRoutineDetails(_routineName);
        }

        private string GetRoutineDetails(string routineName)
        {
            return routineName switch
            {
                "Neck & Shoulders" =>
                "Neck & Shoulders Stretch:\n\n" +
                "1. Sit or stand up straight.\n" +
                "2. Tilt your head gently to one side, bringing your ear toward your shoulder. Hold for 15–20 seconds.\n" +
                "3. Repeat on the other side.\n" +
                "4. Roll your shoulders forward and backward slowly 10 times.\n" +
                "5. Breathe deeply throughout the stretch.",

                "Back Stretch" =>
                "Back Stretch:\n\n" +
                "1. Lie on your back on a mat.\n" +
                "2. Bring both knees toward your chest.\n" +
                "3. Wrap your arms around your legs and gently pull them closer.\n" +
                "4. Hold the position for 20–30 seconds while breathing deeply.\n" +
                "5. Slowly release and repeat 2–3 times.",

                "Full Body" =>
                "Full Body Stretch:\n\n" +
                "1. Stand tall and reach both arms overhead.\n" +
                "2. Lean gently to the right, hold for 10 seconds, then switch to the left.\n" +
                "3. Reach down and touch your toes (or as far as comfortable). Hold for 15 seconds.\n" +
                "4. Stand up and slowly twist your torso left and right.\n" +
                "5. Repeat the sequence 2 times.",

                _ =>
                "Stretching Routine:\n\n" +
                "1. Start with deep breathing to relax your muscles.\n" +
                "2. Gently stretch each major muscle group for 15–30 seconds.\n" +
                "3. Avoid bouncing, and stop if anything feels painful.\n" +
                "4. Aim to stretch daily for flexibility and relaxation."
            };
        }


        private async void OnFinishClicked(object sender, EventArgs e)
        {
            _currentActivity.EndTime = DateTime.Now;
            await _database.EndActivityAsync(_currentActivity);
            await Navigation.PopAsync();
        }


    }
}
