namespace HealthApp;

public partial class Game2Page : ContentPage
{
	string username6;

	public Game2Page(string username)
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		username6 = username;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnPlayClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new LightUpGamePage(username6));
	}
}

