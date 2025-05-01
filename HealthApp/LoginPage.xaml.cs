namespace HealthApp;

public partial class LoginPage : ContentPage
{
	
	private readonly HealthAppViewModel _viewModel; 

	public LoginPage()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		_viewModel = App.ViewModel;
        BindingContext = _viewModel;
	}

	private async void OnLoginClick(object sender, EventArgs e)
	{   
		if (string.IsNullOrEmpty(Username.Text)){
			await DisplayAlert("Username Empty","Please Enter a Username","Okay");
		}

		else if (string.IsNullOrEmpty(Password.Text)){
			await DisplayAlert("Password Empty","Please Enter a Password","Okay");
		}
        
		//Database
		//else if (!await _viewModel.CheckIfUsernameExists(Username.Text)){
		//	await DisplayAlert("Username Not in Database","Please Enter a valid Username","Okay");
		//}

		//else if (await _viewModel.IsValidUser(Username.Text, Password.Text)){
		//	string username = Username.Text;
		//    await Navigation.PushAsync(new HomePage(Username.Text));
		//}
		//else{
		//	await DisplayAlert("Password Not in Database","Please Enter a valid Password","Okay");
		//}
		
		else{await Navigation.PushAsync(new HomePage(Username.Text));}
	}

	private async void OnSignUpClick(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(Username.Text)){
		 	await DisplayAlert("Username Empty","Please Enter a Username","Okay");
		 }

		 else if (string.IsNullOrEmpty(Password.Text)){
		 	await DisplayAlert("Password Empty","Please Enter a Password","Okay");
		 }

		 //else{await _viewModel.RegisterUser(Username.Text, Password.Text);
		 //await Navigation.PushAsync(new HomePage(Username.Text));}

		 else{await Navigation.PushAsync(new HomePage(Username.Text));}
	}
}

