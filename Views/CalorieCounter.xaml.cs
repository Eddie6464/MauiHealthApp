
using Microsoft.Maui.Controls;
using Nutrition.Services;
using Nutrition.ViewModel; 
using System.Collections.ObjectModel; 
using Nutrition.Model;
using Nutrition.Model; 

namespace Nutrition.Views
{
    public partial class CalorieCounter : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public bool IsListVisible { get; set; } // Property to control list visibility


        public ObservableCollection<FoodItem> FilteredFoods { get; private set; } = new ObservableCollection<FoodItem>();

        // Database connection
        public CalorieCounter(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            BindingContext = new CalorieCounterViewModel(_databaseService, Navigation);
        }

        
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = (CalorieCounterViewModel)BindingContext;
            viewModel.OnSearchTextChanged(sender, e);
            
        }

       // Calls for the breakfast items when page appears
        private async void BreakfastItem(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new BreakfastSelection(_databaseService));
		}
        
        // Calls for the lunch items when page appears
        private async void LunchItem(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new LunchSelectionPage(_databaseService));
		}

        // Calls for the dinner items when page appears
        private async void DinnerItem(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new DinnerSelection(_databaseService));
		}

        // Calls for the snack items when page appears
       private async void SnackItem(object sender, EventArgs e)
       {
            await Navigation.PushAsync(new SnackSelection(_databaseService));
       }

        // Calls for the exercise items when page appears
        private async void ExerciseItem(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExerciseSelection(_databaseService));
        }

       
    
    }
}