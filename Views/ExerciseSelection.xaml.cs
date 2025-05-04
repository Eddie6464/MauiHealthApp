using Microsoft.Maui.Controls;
using Nutrition.Services;

namespace Nutrition.Views;

public partial class ExerciseSelection : ContentPage
{
	    private readonly DatabaseService _databaseService;
        
        public ExerciseSelection(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
        }

        // Add exercise to the exercise section of the database so it can take away the caloires the user has burnt
       private async void footballClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("5 a side football 1 hour", 550, "Exercise"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void JoggingClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Jogging 30min", 239, "Exercise"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

       private async void RowingClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Rowing 30min", 239, "Exercise"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void GolfClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Golf driving range 1 hour", 159, "Exercise"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

       private async void CyclingClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Cycling 1 hour", 558, "Exercise"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void SwimmingClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Swimming 30min", 200, "Exercise"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void WaterClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("250ml of Water", 0, "Exercise"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }


        // Calls for the previous page when back button is clicked
		private async void OnBackClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
    }