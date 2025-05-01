namespace HealthApp;

public partial class HomePage : ContentPage
{
	string username2;

	public HomePage(string username)
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		//gets the username from the previous page
		username2=username;

	}

	private void OnGeneralWellbeingClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new HomePage(username2));
	}

	private void OnImmediateWellbeingClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MainPage(username2));
	}

	private void OnNutritionClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new HomePage(username2));
	}

	private void OnPhysicalHealthClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new HomePage(username2));
	}
}

