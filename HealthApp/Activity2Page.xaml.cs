namespace HealthApp;

public partial class Activity2Page : ContentPage
{
	public Activity2Page()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		//labels set to show user the activity steps
		string Text1 = "Step 1: Holding tension for 5 seconds";
		string Text2 = "Step 2: Release muscle";
		string Text3 = "Step 3: Let muscle realx for 10 seconds before moving onto next";
	    Label1.Text=Text1;
		Label2.Text=Text2;
		Label3.Text=Text3;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}

