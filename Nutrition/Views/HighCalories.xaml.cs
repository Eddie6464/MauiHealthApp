namespace Nutrition.Views;

public partial class HighCalories : ContentPage
{
	public HighCalories()
	{
		InitializeComponent();
		this.BackgroundColor = Color.FromHex("#F5CDAA");
	}

	private async void HighCaloriesSteps_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("HighCaloriesSteps");
	}

}
