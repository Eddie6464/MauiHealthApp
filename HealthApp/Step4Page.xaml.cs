namespace HealthApp;

public partial class Step4Page : ContentPage
{
	List<string> steplist4;

	string username9;

	public Step4Page(List<string> steplist, string username)
	{
		InitializeComponent();
	    NavigationPage.SetHasNavigationBar(this, false);
		steplist4 = steplist;
		username9 = username;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnPlansEndClick(object sender, EventArgs e)
	{
		steplist4.Add(Entry.Text);
		Navigation.PushAsync(new PlansEndPage(steplist4, username9));
	}
}

