namespace EnergyHealthApp.Views;

public partial class OverviewPage : ContentPage
{
	public OverviewPage()
	{
		InitializeComponent();
	}

	private async void HomeButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EnergyMainPage());
	}
}