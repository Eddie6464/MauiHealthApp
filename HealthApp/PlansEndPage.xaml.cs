namespace HealthApp;

public partial class PlansEndPage : ContentPage
{
	List<string> steplist5;
    private readonly HealthAppViewModel _viewModel; 
	string username10;
	public PlansEndPage(List<string> steplist, string username)
	{
		InitializeComponent();
	    NavigationPage.SetHasNavigationBar(this, false);
		steplist5 = steplist;
		username10 = username;
	}

	private async void OnAddPlanClick(object sender, EventArgs e)
	{
		//await _viewModel.AddSteps(await _viewModel.FetchUserId(username10), steplist5[0], steplist5[1], steplist5[2], steplist5[3]);
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnMakingPlansClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MakingPlansPage(username10));
	}

	private void OnShowPlansClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new ShowPlansPage(username10));
	}

}