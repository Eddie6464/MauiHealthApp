namespace HealthApp;

public partial class PlansPage : ContentPage
{
	string username5;
	public PlansPage(string username)
	{
		InitializeComponent();
	    NavigationPage.SetHasNavigationBar(this, false);
		//gets username from previous page
		username5 = username;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnStep1Click(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Step1Page(username5));
	}
}

