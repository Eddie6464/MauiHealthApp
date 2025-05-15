namespace Nutrition.Views;

public partial class Question1 : ContentPage
{
	public Question1()
	{
		InitializeComponent();
		this.BackgroundColor = Color.FromArgb("#F5CDAA"); // Light Orange color
        
	}

	 private async void Question2_Clicked(object sender, EventArgs e)
        {

            var button = sender as Button;
            string GenderText = button.Text;

            Model.SharedData.GenderText = GenderText;
            
            // Takes the user to Question 2
           await Shell.Current.GoToAsync("Question2");
			
       }

}