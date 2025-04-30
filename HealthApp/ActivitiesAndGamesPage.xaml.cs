namespace HealthApp;

public partial class ActivitiesAndGamePage : ContentPage
{

   string username4;
	public ActivitiesAndGamePage(string username)
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		username4 = username;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnGamesClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new GamesPage(username4));
	}

	private void OnActivitiesClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new ActivitiesPage());
	}
}

