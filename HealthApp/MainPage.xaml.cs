namespace HealthApp;

public partial class MainPage : ContentPage
{
	string username3;

	public MainPage(string username)
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		//gets username from previuos page
		username3=username;
	}

	private void OnGeneralHelpButtonClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new GeneralHelpPage());
	}

	private void OnActivitiesAndGamesButtonClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new ActivitiesAndGamePage(username3));
	}

	private void OnMakingPlansButtonClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MakingPlansPage(username3));
	}

}

