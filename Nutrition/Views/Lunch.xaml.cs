namespace Nutrition.Views;

public partial class Lunch : ContentPage
{
	public Lunch()
	{
		InitializeComponent();
		this.BackgroundColor = Color.FromHex("#F5CDAA");
	}

	private async void LunchSteps_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("LunchSteps");
	}
}
