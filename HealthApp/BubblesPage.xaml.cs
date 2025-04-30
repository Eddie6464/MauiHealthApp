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
