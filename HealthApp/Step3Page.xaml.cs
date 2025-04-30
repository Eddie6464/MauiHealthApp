namespace HealthApp;

public partial class Step3Page : ContentPage
{
	List<string> steplist3;
	string username8;
	public Step3Page(List<string> steplist, string username)
	{
		InitializeComponent();
	    NavigationPage.SetHasNavigationBar(this, false);
		steplist3 = steplist;
		username8 = username;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnStep4Click(object sender, EventArgs e)
	{
		steplist3.Add(Entry.Text);
		Navigation.PushAsync(new Step4Page(steplist3, username8));
	}
}

