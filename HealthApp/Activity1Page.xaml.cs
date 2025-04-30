namespace HealthApp;

public partial class Activity1Page : ContentPage
{
	public Activity1Page()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		string Text1 = "Step 1: Look at 5 seperate objects and think about them for a while";
		string Text2 = "Step 2: Listen to 4 sounds and consider where they can from";
		string Text3 = "Step 3: Touch 3 objects and consider the temperature and texture";
		string Text4 = "Step 4: Identify 2 smells such as coffee or soap";
		string Text5 = "Step 5: Name one thing you can taste such as eating a sweet";
	    Label1.Text=Text1;
		Label2.Text=Text2;
		Label3.Text=Text3;
		Label4.Text=Text4;
		Label5.Text=Text5;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}

