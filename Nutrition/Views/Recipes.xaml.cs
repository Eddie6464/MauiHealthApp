namespace Nutrition.Views;

public partial class Recipes : ContentPage
{
	public Recipes()
	{
		InitializeComponent();
		this.BackgroundColor = Color.FromArgb("#F5CDAA");
	}

	// Takes the user to there chosen screen
	private async void LowCalories_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("LowCalories");
	}

	private async void HighCalories_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("HighCalories");
	}

	private async void Snacks_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("Snack");
	}

	private async void GlutenFree_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("GlutenFree");
	}

	private async void Lunch_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("Lunch");
	}

	private async void Breakfast_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("Breakfast");
	}
}

	