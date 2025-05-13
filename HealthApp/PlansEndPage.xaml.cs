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
		//gets username and steplist from previous page
		steplist5 = steplist;
		username10 = username;
	}

	private async void OnAddPlanClick(object sender, EventArgs e)
	{   
		//Database
		//await _viewModel.AddSteps(await _viewModel.FetchUserId(username10), steplist5[0], steplist5[1], steplist5[2], steplist5[3]);
		S1.Text=steplist5[0];
		S2.Text=steplist5[1];
		S3.Text=steplist5[2];
		S4.Text=steplist5[3];
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnMakingPlansClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MakingPlansPage(username10));
	}

}