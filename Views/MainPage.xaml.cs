namespace Nutrition.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		 this.BackgroundColor = Color.FromArgb("#BBFBBB");
	}

	// Takes the user to there chosen screen
	private async void WeightPlan_Clicked(object sender, EventArgs e)
	{
		// Navigate to the specified URL in the system browser.
		await Shell.Current.GoToAsync("Question1");
	}

	private async void CalorieCounter_Clicked(object sender, EventArgs e)
	{
		
		await Shell.Current.GoToAsync("CalorieCounter");
	}

	private async void BestFood_Clicked(object sender, EventArgs e)
	{
		
		await Shell.Current.GoToAsync("BestFoods");
	}

	private async void Recipes_Clicked(object sender, EventArgs e)
	{
		
		await Shell.Current.GoToAsync("Recipes");
	}

}
