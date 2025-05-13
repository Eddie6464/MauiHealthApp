namespace HealthApp;

public partial class LightUpScores : ContentPage
{
	private readonly HealthAppViewModel _viewModel; 
	string username10;

	public LightUpScores(string username)
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		_viewModel = App.ViewModel;
        BindingContext = _viewModel;
		username10 = username;
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
		   //Database
           //label.Text=await _viewModel.GetLightUpGameScores(username10, parsedDate1, parsedDate2);
           label.Text="database unavailable";
        }
        else{
           await DisplayAlert("Invalid Date", "Please enter valid dates in both fields.", "OK");
		   label.Text="invalid input";
        }
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}
