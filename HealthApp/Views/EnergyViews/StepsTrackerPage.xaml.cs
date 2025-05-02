namespace EnergyHealthApp.Views;


public partial class StepsTrackerPage : ContentPage
{
	public StepsTrackerPage()
	{
		InitializeComponent();
	}
    
    private async void HomeButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EnergyMainPage());
	}

	private async void StepsButtonClicked(object sender, EventArgs e)
	{
        StepsLabel.Text = "Retrieving steps data!";
        int StepsCount = await GetStepsCountAsync();
        StepsLabel.Text = $"You have walked {StepsCount} steps today!";
        await Task.Delay(2000);
        SuggestionLabel.Text = $"Why not try walking {StepsCount+1000} steps tomorrow?";
	}

    private async static Task<int> GetStepsCountAsync()
    {
        await Task.Delay(2000); 

        Random random = new();

        return random.Next(1000, 10000); 
    }

}