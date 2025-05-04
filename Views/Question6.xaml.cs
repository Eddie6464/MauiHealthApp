namespace Nutrition.Views;

public partial class Question6 : ContentPage
{
	public Question6()
	{
		InitializeComponent();
		 this.BackgroundColor = Color.FromArgb("#F5CDAA"); // Light Orange color


	}

	private async void Question7_Clicked(object sender, EventArgs e)
	{
		var button = sender as Button;
        string Weighttype = button.Text;

		// Shared data
        Model.SharedData.Weighttype = Weighttype;



		// Handle the button click to take the user to the next screen
		await Shell.Current.GoToAsync("Question7");
	}
}