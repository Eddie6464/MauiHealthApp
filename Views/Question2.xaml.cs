namespace Nutrition.Views
{
    public partial class Question2 : ContentPage
    {
        public Question2()
        {
            InitializeComponent();
             this.BackgroundColor = Color.FromArgb("#F5CDAA"); // Light Orange color
        }

        private async void Question3_Clicked(object sender, EventArgs e)
        {

            string ageText = AgeEntry.Text;
            
         // Set the shared data
        Model.SharedData.ageText = ageText;

		
		// Handle the button click event if age is null or empty
        if (string.IsNullOrWhiteSpace(AgeEntry.Text))
            {
                await DisplayAlert("Error", "Please enter your age before submitting.", "OK");
            }
        // Handle the button click event if age is not a number or less than 1
        else if (!int.TryParse(AgeEntry.Text, out int age) || age < 1)
            {
                await DisplayAlert("Error", "Please enter a valid age.", "OK");
            }
        // Handle the button click event if age is greater than 120
        else if (age > 120)
            {
                await DisplayAlert("Error", "Please enter a realistic age.", "OK");
            }
            
        else
            // Handle the button click event if age is not null or empty and is correct 
            await Navigation.PushAsync(new Question3(ageText));
       }

    }
}
