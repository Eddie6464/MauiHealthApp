namespace Nutrition.Views;

public partial class Question3 : ContentPage
{
	public Question3(string ageText)
	{
		InitializeComponent();
		 this.BackgroundColor = Color.FromArgb("#F5CDAA"); // Light Orange color
		
		
	}

	 private async void Question4_Clicked(object sender, EventArgs e)
        {

			
            string stonesText = StonesEntry.Text;
            string poundsText = PoundsEntry.Text;

            // Set the shared data
            Model.SharedData.StonesText = stonesText;
            Model.SharedData.PoundsText = poundsText;



            // Handle the button click event if stones or pounds is null or empty
            if (string.IsNullOrWhiteSpace(StonesEntry.Text) || string.IsNullOrWhiteSpace(PoundsEntry.Text))
            {
                await DisplayAlert("Error", "please enter a value in the input box.", "OK");
            }
            // Handle the button click event if stones or pounds is not a integer
            else if (!int.TryParse(StonesEntry.Text, out int stones) || !int.TryParse(PoundsEntry.Text, out int pound))
            {
                await DisplayAlert("Error", "Please enter a valid weight", "OK");
            }    
            // Handle the button click event if stones or pounds is less than 0
            else if (stones < 0 || pound < 0)
            {
                await DisplayAlert("Error", "Please enter a realisitc weight", "OK");
            }
            // Handle the button click event if stone or pound is unrealistic
            else if (stones > 50 || pound > 100)
            {
                await DisplayAlert("Error", "Please enter a realistic weight", "OK");
            }
            // Handle the button click event if stones and pounds is correct
            else
                await Shell.Current.GoToAsync("Question4");
       }
}