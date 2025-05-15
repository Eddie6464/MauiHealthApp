using MentalHealthApp.Models;
using MentalHealthApp.Services;

namespace MentalHealthApp
{
    public partial class BreathingExercisePage : ContentPage
    {
        private readonly DatabaseService _database;
        private readonly ActivityLog _currentActivity;
        private readonly string _exerciseName;

        public BreathingExercisePage(DatabaseService database, ActivityLog currentActivity, string exerciseName)
        {
            InitializeComponent();
            _database = database;
            _currentActivity = currentActivity;
            _exerciseName = exerciseName;

            ExerciseNameLabel.Text = _exerciseName;
            ExerciseDetailsLabel.Text = GetExerciseDetails(_exerciseName);
        }

        private string GetExerciseDetails(string exerciseName)
        {
            return exerciseName switch
            {
                "4-7-8 Breathing" =>
                "4-7-8 Breathing Technique:\n\n" +
                "1. Sit or lie down comfortably.\n" +
                "2. Inhale quietly through your nose for 4 seconds.\n" +
                "3. Hold your breath for 7 seconds.\n" +
                "4. Exhale slowly through your mouth for 8 seconds.\n" +
                "5. Repeat for 4 cycles.\n\n" +
                "Tip: This technique helps calm the nervous system and reduce anxiety.",

                "Box Breathing" =>
                "Box Breathing (a.k.a. Square Breathing):\n\n" +
                "1. Inhale through your nose for 4 seconds.\n" +
                "2. Hold your breath for 4 seconds.\n" +
                "3. Exhale slowly for 4 seconds.\n" +
                "4. Hold again for 4 seconds.\n" +
                "5. Repeat the cycle for 4–5 minutes.\n\n" +
                "Tip: This is used by athletes and military personnel to stay calm and focused.",

                "Diaphragmatic Breathing" =>
                "Diaphragmatic (Belly) Breathing:\n\n" +
                "1. Sit or lie down with one hand on your chest and the other on your belly.\n" +
                "2. Inhale deeply through your nose. Your belly should rise more than your chest.\n" +
                "3. Exhale slowly through pursed lips.\n" +
                "4. Focus on your belly expanding as you breathe in.\n" +
                "5. Continue for 5–10 minutes.\n\n" +
                "Tip: This helps improve oxygen intake and relax your body.",

                _ =>
                "Breathing Exercise:\n\n" +
                "1. Sit in a comfortable position.\n" +
                "2. Close your eyes and take slow, deep breaths.\n" +
                "3. Focus on your breath — inhale calmly, exhale slowly.\n" +
                "4. Try to stay present and let go of distractions."
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
