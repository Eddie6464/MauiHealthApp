using Microsoft.Maui.Controls;
using Nutrition.Services;
namespace Nutrition.Views;

public partial class BreakfastSelection : ContentPage
{
	    private readonly DatabaseService _databaseService;
        
        public BreakfastSelection(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
        }

       // Add food item to database
       private async void MilkClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Semi skinned 125ml Milk", 58, "Breakfast"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void BananaClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Banana Weighted without skin 100g", 81, "Breakfast"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void SausuagesClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Thick Pork Sausages 40g", 236, "Breakfast"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void BeansClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Baked Beans small tin 150g", 122, "Breakfast"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

       private async void BaconClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Bacon Rashers Grilled 50g", 144, "Breakfast"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void WeetabixClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("Weetabix 100g", 366, "Breakfast"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }

        private async void WaterClicked(object sender, EventArgs e)
        {
            await _databaseService.AddFoodAsync("250ml of Water", 0, "Breakfast"); // Fixed
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "RefreshFoods");
        }
		private async void OnBackClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
    }