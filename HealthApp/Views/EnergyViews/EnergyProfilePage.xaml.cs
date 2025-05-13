namespace EnergyHealthApp.Views;
using EnergyHealthApp.ViewModels;
using EnergyHealthApp.Helpers;


public partial class EnergyProfilePage : ContentPage
{
	private readonly ViewEnergyProfileViewModel? _viewModel;
	public EnergyProfilePage(ViewEnergyProfileViewModel vm)
	{
		InitializeComponent();
		_viewModel = vm;
		BindingContext = _viewModel;

		if (_viewModel is not null)
		{
			this.Appearing += async (s, e) => await _viewModel.LoadUserData(1); 
		}
	}

	private async void HomeButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EnergyMainPage());
	}

	private async void UpdateButtonClicked(object sender, EventArgs e)
	{
		var vm = ServiceHelper.GetService<UpdateEnergyProfileViewModel>();
		await Navigation.PushAsync(new EnergyProfileEntryPage(vm));
	}
}