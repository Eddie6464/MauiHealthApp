namespace Nutrition.Views;

public partial class Question5 : ContentPage
{
	public Question5()
	{
		InitializeComponent();
		 this.BackgroundColor = Color.FromArgb("#F5CDAA"); // Light Orange color
	}

	private async void Question6_Clicked(object sender, EventArgs e)
	{
		var button = sender as Button;
        string activeText = button.Text;

		// Show the light and job with long periods of sitting button are the same option
		if (activeText == "Light" || activeText == "Job with long periods of sitting")
		{
			// Set the shared data
			Model.SharedData.activeText = "Light";
		}
		else if (activeText == "Moderate" || activeText == "On your feet most of the day")
		{
			Model.SharedData.activeText = "Moderate";
		}
		else 
		{
			Model.SharedData.activeText = "High";
		}
		


		// Handle the button click event to take the user to the next screen
		await Shell.Current.GoToAsync("Question6");
	}
}