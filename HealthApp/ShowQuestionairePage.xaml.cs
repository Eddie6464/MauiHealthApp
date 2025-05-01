namespace HealthApp;

public partial class ShowQuestionairePage : ContentPage
{
	private readonly HealthAppViewModel _viewModel; 

	string username5;

	public ShowQuestionairePage(string username)
	{
		InitializeComponent();
	    NavigationPage.SetHasNavigationBar(this, false);
		//gets username from previous page
		username5 = username;
	}

	private async void OnEnterClick(object sender, EventArgs e)
	{
		string inputText = Entry.Text;

        if (int.TryParse(inputText, out int Entrynumber)){
        //    Question1.Text = (await _viewModel.GetQuestion1(username5, Entrynumber)).ToString();
		//    Question2.Text = (await _viewModel.GetQuestion2(username5, Entrynumber)).ToString();
		//    Question3.Text = (await _viewModel.GetQuestion3(username5, Entrynumber)).ToString();
		//    Question4.Text = (await _viewModel.GetQuestion4(username5, Entrynumber)).ToString();
		//    Question5.Text = (await _viewModel.GetQuestion5(username5, Entrynumber)).ToString();
		//    Question6.Text = (await _viewModel.GetQuestion6(username5, Entrynumber)).ToString();
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