using Microsoft.Maui.Controls;
using Nutrition.Services;



namespace Nutrition.Views;

public partial class SnackSelection : ContentPage
{
	    private readonly DatabaseService _databaseService;
        
        public SnackSelection(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
        }

        // Add food item to the snack section of the database
       private async void BlueberriesClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Blueberries 100g", 40, "Snack"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void GrapesClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Red grapes 100g", 67, "Snack"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

       private async void KitKatClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("One Kit Kat", 104, "Snack"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void AlmondsClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Almonds 8g", 44, "Snack"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

       private async void SatsumasClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Satsumas 90g", 37, "Snack"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void RichTeaClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("One McVities Rich Tea", 250, "Snack"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void WaterClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("250ml of Water", 0, "Snack"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        /// Back button to go back to the calorie counter screen
		private async void OnBackClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
    }