namespace HealthApp;

public partial class ShowPlansPage : ContentPage
{
	private readonly HealthAppViewModel _viewModel; 

	string username5;

	public ShowPlansPage(string username)
	{
		InitializeComponent();
	    NavigationPage.SetHasNavigationBar(this, false);
		username5 = username;
	}

	private async void OnEnterClick(object sender, EventArgs e)
	{
		string inputText = Entry.Text;

        if (int.TryParse(inputText, out int Entrynumber)){
           //Step1.Text = await _viewModel.GetStep1(username5, Entrynumber);
		   //Step2.Text = await _viewModel.GetStep2(username5, Entrynumber);
		   //Step3.Text = await _viewModel.GetStep3(username5, Entrynumber);
		   //Step4.Text = await _viewModel.GetStep4(username5, Entrynumber);
        }
        else{
           await DisplayAlert("Invalid Input", "Please enter a valid number.", "OK");
        }
		

	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnMakingPlansClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MakingPlansPage(username5));
	}


}