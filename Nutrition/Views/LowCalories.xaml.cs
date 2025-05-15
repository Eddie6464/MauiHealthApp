namespace Nutrition.Views;

public partial class LowCalories : ContentPage
{
	public LowCalories()
	{
		InitializeComponent();
		this.BackgroundColor = Color.FromHex("#F5CDAA");
	}
	
	private async void LowCaloriesSteps_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("LowCaloriesSteps");
	}

}
