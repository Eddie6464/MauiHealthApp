using Microsoft.Maui.Controls;
using Nutrition.Services;

namespace Nutrition.Views;

public partial class LunchSelectionPage : ContentPage
{
	 private readonly DatabaseService _databaseService;
        
        public LunchSelectionPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
        }

        // Add food item to the lunch section of the database
       private async void BaguatteClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("White baguatte 150g", 452, "Lunch"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void ButterClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Lurpak slightly salted butter 5g", 68, "Lunch"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void BreadClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("White Bread 25g slice", 55, "Lunch"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void HamClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Regular slice of Ham", 27, "Lunch"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void TomatoClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("5 x Cherry Tomatoes", 17, "Lunch"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void EggClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Egg 50g", 66, "Lunch"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void WaterClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("250ml of Water", 0, "Lunch"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        // Calls for the back button to go back to the previous page
		private async void OnBackClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
    }