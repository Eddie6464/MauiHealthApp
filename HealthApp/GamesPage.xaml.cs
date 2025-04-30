namespace HealthApp;

public partial class GamesPage : ContentPage
{
	string username5;

	public GamesPage(string username)
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		username5 = username;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnGame1Click(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Game1Page());
	}

	private void OnGame2Click(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Game2Page(username5));
	}

	private void OnGame3Click(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Game3Page(username5));
	}
}

