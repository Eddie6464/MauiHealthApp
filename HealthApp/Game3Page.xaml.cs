namespace HealthApp;

public partial class Game3Page : ContentPage
{
	string username7;

	public Game3Page(string username)
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		username7 = username;
	}

	private void OnPlayClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MentalHealthGamePage(username7));
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}

