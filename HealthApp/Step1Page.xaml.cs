namespace HealthApp;

public partial class Step1Page : ContentPage
{
	public List<string> steplist = new List<string>();
	string username6;

	public Step1Page(string username)
	{
		InitializeComponent();
	    NavigationPage.SetHasNavigationBar(this, false);
		//gets username from previuos page
		username6 = username;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnStep2Click(object sender, EventArgs e)
	{
		steplist.Add(Entry.Text);
		Navigation.PushAsync(new Step2Page(steplist, username6));
	}
}

