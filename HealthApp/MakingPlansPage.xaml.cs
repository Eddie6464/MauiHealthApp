namespace HealthApp;

public partial class MakingPlansPage : ContentPage
{
	string username4;

	public MakingPlansPage(string username)
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		//gets username from previous page
		username4 = username;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MainPage(username4));
	}

	private void OnPlansClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new PlansPage(username4));
	}

	private void OnShowPlansClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new ShowPlansPage(username4));
	}

	private void OnQuestionaireClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new QuestionairePage(username4));
	}

}

