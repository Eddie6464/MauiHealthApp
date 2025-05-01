namespace HealthApp;

public partial class PanicPage : ContentPage
{
	//int count = 0;

	public PanicPage()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		//labels set to reccomedations to manage OCD
		string Text1 = "Focus on what is going on around you and try to; \nListen to music \nCount the objects around you \nSomething you enjoy such as reading or watching television";
		string Text2 = "Some panic attacks come from being overwhelmed, so try closing you eyes or covering your ears";
		string Text3 = "Pick an object to focus all your attention on and try to describe the patterns, colour, shape, and size of the object";
		string Text4 = "Certain things can trigger panic attacks, try to find out your triggers, so you can manage or avoid them, they could include; enclosed spaces or crowds";
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

