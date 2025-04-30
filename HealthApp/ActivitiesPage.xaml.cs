namespace HealthApp;

public partial class ActivitiesPage : ContentPage
{
	//int count = 0;

	public ActivitiesPage()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnActivity1Click(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Activity1Page());
	}

	private void OnActivity2Click(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Activity2Page());
	}

	private void OnActivity3Click(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Activity3Page());
	}

	private void OnActivity4Click(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Activity4Page());
	}
}

