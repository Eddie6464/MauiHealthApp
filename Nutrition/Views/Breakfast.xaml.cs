namespace Nutrition.Views;

public partial class Breakfast : ContentPage
{
	public Breakfast()
	{
		InitializeComponent();
		this.BackgroundColor = Color.FromHex("#F5CDAA");
	}

	private async void BreakfastSteps_Clicked (object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("BreakfastSteps");
	}
}
