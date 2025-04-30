namespace HealthApp;

public partial class StressPage : ContentPage
{
	//int count = 0;

	public StressPage()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		string Text1 = "Try listening to music, as this can relax you";
		string Text2 = "Give yourself a hand message, by keanding the base of the muscle under your thumb, as this can help reduce your heart rate and reduce stress";
		string Text3 = "Eat some chocolate - One square of dark chocolate can help calm your nerves, as it regualtes the stress hormone corisol";
		string Text4 = "You may feel like you want to do everything, but sometimes you will need to learn to say no to somethings to help manage your to-do list and stress. These healthy boundries are important to managing stress.";
	    Label1.Text=Text1;
		Label2.Text=Text2;
		Label3.Text=Text3;
		Label4.Text=Text4;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}

