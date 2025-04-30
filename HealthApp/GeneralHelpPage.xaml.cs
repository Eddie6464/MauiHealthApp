namespace HealthApp;

public partial class GeneralHelpPage : ContentPage
{

	public GeneralHelpPage()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnPanicClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new PanicPage());
	}

	private void OnStressClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new StressPage());
	}

	private void OnOCDClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new OCDPage());
	}


}

