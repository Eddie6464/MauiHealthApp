namespace HealthApp;

public partial class Activity4Page : ContentPage
{

	public Activity4Page()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		string Text1 = "Step 1: Setting at least 20 minutes aside";
		string Text2 = "Step 2: Find a comfortable place such as a chair or bed";
		string Text3 = "Step 3: Close your eyes and focus on your senses";
		string Text4 = "Step 4: Start slowly breathing in and out";
		string Text5 = "Step 5: When you get distracted by a though, make sure to bring your mind back to breathing";
		string Text6 = "Step 6: Once finished stay seated a little longer before you get up";
	    Label1.Text=Text1;
		Label2.Text=Text2;
		Label3.Text=Text3;
		Label4.Text=Text4; 
		Label5.Text=Text5;
		Label6.Text=Text6;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}

