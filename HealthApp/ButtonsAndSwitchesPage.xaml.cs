namespace HealthApp;

public partial class ButtonsAndSwitchesPage : ContentPage
{

	public ButtonsAndSwitchesPage()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnSquareClick(object sender, EventArgs e)
{
    //when a button is clicked if it is red it will change to oranage, and if it is orange it will change to
    //yellow, and so on
    if (sender is Button button)
    {
        if (button.BackgroundColor == Colors.Red)
        {
            button.BackgroundColor = Colors.Orange;
        }
        else if (button.BackgroundColor == Colors.Orange)
        {
            button.BackgroundColor = Colors.Yellow;
        }
        else if (button.BackgroundColor == Colors.Yellow)
        {
            button.BackgroundColor = Colors.Green;
        }
        else if (button.BackgroundColor == Colors.Green)
        {
            button.BackgroundColor = Colors.Blue;
        }
        else if (button.BackgroundColor == Colors.Blue)
        {
            button.BackgroundColor = Colors.Purple;
        }
        else if (button.BackgroundColor == Colors.Purple)
        {
            button.BackgroundColor = Colors.DeepPink;
        }
        else if (button.BackgroundColor == Colors.DeepPink)
        {
            button.BackgroundColor = Colors.Red;
        }
    }
}

private void OnChangesClick(object sender, EventArgs e)
{
    //when a button is pressed if it is green, that button will chnage to red, and other button will change
    //to green
    if (button1.BackgroundColor == Colors.Red)
    {
        button1.BackgroundColor = Colors.LawnGreen;
		button1.Text = "On";
		button2.BackgroundColor = Colors.Red;
		button2.Text = "Off";
    }

    else 
    {
        button1.BackgroundColor = Colors.Red;
		button1.Text = "Off";
		button2.BackgroundColor = Colors.LawnGreen;
		button2.Text = "On";
    }
    }
}

