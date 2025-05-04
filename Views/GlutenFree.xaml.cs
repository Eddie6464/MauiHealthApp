namespace Nutrition.Views;

public partial class GlutenFree : ContentPage
{
	public GlutenFree()
	{
		InitializeComponent();
		this.BackgroundColor = Color.FromHex("#F5CDAA");
	}

	private async void GlutenFreeSteps_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("GlutenFreeSteps");
	}
}