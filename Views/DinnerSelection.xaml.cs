using Microsoft.Maui.Controls;
using Nutrition.Services;

namespace Nutrition.Views;

public partial class DinnerSelection : ContentPage
{
	    private readonly DatabaseService _databaseService;
        
        public DinnerSelection(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
        }

        // Add food item to the dinner section of the database
       private async void OnPizzaClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Small Pepperoni Pizza", 867, "Dinner"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void OnFriesClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Small Portion of french fries", 232, "Dinner"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }
        
        private async void ChickenClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Chicken Breast 100g", 106, "Dinner"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void RiceClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Basmati Rice 150g", 176, "Dinner"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void PotatoClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Potato 213g", 164, "Dinner"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void SalmonClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Salmon Fillet 125g", 271, "Dinner"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void WaterClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("250ml of Water", 0, "Dinner"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

		private async void OnBackClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
    }