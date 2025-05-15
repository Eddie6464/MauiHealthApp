namespace Nutrition.Views;

public partial class Question4 : ContentPage
{
	public Question4()
	{
		InitializeComponent();
		 this.BackgroundColor = Color.FromArgb("#F5CDAA"); // Light Orange color

	}

	private async void Question5_Clicked(object sender, EventArgs e)
	{
		string feetText = FeetEntry.Text;
		string inchesText = InchesEntry.Text;

		// Set the shared data
		Model.SharedData.FeetText = feetText;
		Model.SharedData.InchesText = inchesText;

		// Handle the button click event here
		if (string.IsNullOrWhiteSpace(FeetEntry.Text) || string.IsNullOrWhiteSpace(InchesEntry.Text))
            {
                await DisplayAlert("Error", "Please enter information before submitting.", "OK");
            }
		// Handle the button click event if feet or inches is not a number
		else if (!int.TryParse(FeetEntry.Text, out int feet) || !int.TryParse(InchesEntry.Text, out int inches))
			{
				await DisplayAlert("Error", "Please enter a valid height.", "OK");
			}
		// Handle the button click event if feet or inches is unrealistic
		else if (feet > 20 || inches > 100)
			{
				await DisplayAlert("Error", "Please enter a realistic height.", "OK");
			}
		// Handle the button click event if feet or inches is less than 1
		else if (feet < 1 || inches < 1)
			{
				await DisplayAlert("Error", "Please enter a positive height.", "OK");
			}
		
		// Handle the button click event if feet and inches is correct
         else
                await Shell.Current.GoToAsync("Question5");
       }
}
