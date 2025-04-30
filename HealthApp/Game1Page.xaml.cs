namespace HealthApp;

public partial class Game1Page : ContentPage
{

	public Game1Page()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
	}

	private void OnSpinnerClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new SpinnerPage());
	}

	private void OnBubblesClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new BubblesPage());
	}

	private void OnButtonsAndSwitchesClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new ButtonsAndSwitchesPage());
	}


	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}
