namespace EnergyHealthApp.Views;

public partial class GlossaryPage : ContentPage
{
	public GlossaryPage()
	{
		InitializeComponent();
	}

	private async void HomeButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EnergyMainPage());
	}
}