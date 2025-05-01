namespace HealthApp;

public partial class BubblesPage : ContentPage
{

	public BubblesPage()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnBubbleClick(object sender, EventArgs e)
        {
            //when a button is clicked if it is green it is changed to light green, and if it is
            //light green it is changed to green
            if (sender is Button button)
            {
                if (button.BackgroundColor == Colors.Green)
                {
                    button.BackgroundColor = Colors.LawnGreen; 
                }
                else
                {
                    button.BackgroundColor = Colors.Green; 
                }
            }
        }
}
