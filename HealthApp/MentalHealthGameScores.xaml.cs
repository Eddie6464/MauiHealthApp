namespace HealthApp;

public partial class MentalHealthGameScores : ContentPage
{
	private readonly HealthAppViewModel _viewModel;
	string username9; 

	public MentalHealthGameScores(string username)
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		_viewModel = App.ViewModel;
        BindingContext = _viewModel;
		//gets username from previous page
		username9 = username;
	}


	private async void OnEnterClick(object sender, EventArgs e)
	{
		string inputDate1 = Entry1.Text;  
        string inputDate2 = Entry2.Text;  

        DateTime parsedDate1, parsedDate2;

        bool isValidDate1 = DateTime.TryParse(inputDate1, out parsedDate1);
        bool isValidDate2 = DateTime.TryParse(inputDate2, out parsedDate2);

        // If both dates are valid
        if (isValidDate1 && isValidDate2){
           //label.Text=await _viewModel.GetLightUpGameScores(username9, parsedDate1, parsedDate2);
		   label.Text="database unavailable";
        }
        else{
           await DisplayAlert("Invalid Date", "Please enter valid dates in both fields.", "OK");
        }
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}
