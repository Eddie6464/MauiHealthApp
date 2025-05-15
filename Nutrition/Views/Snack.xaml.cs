namespace Nutrition.Views;

public partial class Snack : ContentPage
{
	public Snack()
	{
		InitializeComponent();
		this.BackgroundColor = Color.FromHex("#F5CDAA");
	}

	private async void SnackSteps_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("SnackSteps");
	}
}