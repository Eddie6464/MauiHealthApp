namespace EnergyHealthApp.Views;


public partial class WorkoutStartPage : ContentPage
{
	public WorkoutStartPage()
	{
		InitializeComponent();
	}
    
    private async void HomeButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EnergyMainPage());
	}

	private async void StartWorkoutButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new WorkoutPage());
	}

}