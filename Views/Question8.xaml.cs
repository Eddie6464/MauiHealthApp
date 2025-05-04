namespace Nutrition.Views;

public partial class Question8 : ContentPage
{
	public Question8()
	{
		InitializeComponent();
		 this.BackgroundColor = Color.FromArgb("#F5CDAA"); // Light Orange colour
	
	    
	}

	private async void CalorieCounter_Clicked(object sender, EventArgs e)
	{
         var button = sender as Button;
		 string AmountText = button.Text;

		 if (AmountText == "0.5 lbs per week")
		{
			// Set the shared data
			Model.SharedData.AmountText = "0.5";
		}
		else if (AmountText == "1 lbs per week")
		{
			// Set the shared data
			Model.SharedData.AmountText = "1";
		}

		else if (AmountText == "1.5 lbs per week")
		{
			Model.SharedData.AmountText = "1.5";
		}
		else
		{
			Model.SharedData.AmountText = "2";
		}
		

		// Handle the button click event here to take the user to the calorie counter screen
		await Shell.Current.GoToAsync("CalorieCounter");
	}
}