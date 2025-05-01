namespace HealthApp;

public partial class Activity3Page : ContentPage
{
	public Activity3Page()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		//labels set to show user the activity steps
		string Text1 = "Step 1: Breathing in for 4 seconds";
		string Text2 = "Step 2: Hold breath for 7 seconds";
		string Text3 = "Step 3: Exhale for 8 seconds";
	    Label1.Text=Text1;
		Label2.Text=Text2;
		Label3.Text=Text3;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}

