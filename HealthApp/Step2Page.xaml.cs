namespace HealthApp;

public partial class Step2Page : ContentPage
{
	List<string> steplist2;
	string username7;

	public Step2Page(List<string> steplist, string username)
	{
		InitializeComponent();
	    NavigationPage.SetHasNavigationBar(this, false);
		steplist2 = steplist;
		username7 = username;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnStep3Click(object sender, EventArgs e)
	{
		steplist2.Add(Entry.Text);
		Navigation.PushAsync(new Step3Page(steplist2, username7));
	}
}

