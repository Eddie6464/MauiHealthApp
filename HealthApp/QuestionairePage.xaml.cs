namespace HealthApp;

public partial class QuestionairePage : ContentPage
{
	string username5;

	public QuestionairePage(string username)
	{
		InitializeComponent();
	    NavigationPage.SetHasNavigationBar(this, false);
		username5 = username;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnQuestion1Click(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Question1Page(username5));
	}

}

