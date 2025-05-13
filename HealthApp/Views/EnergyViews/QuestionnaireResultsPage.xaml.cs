namespace EnergyHealthApp.Views;
using EnergyHealthApp.ViewModels;
using EnergyHealthApp.Helpers;

public partial class QuestionnaireResultsPage : ContentPage
{

	private readonly ViewQuestionnaireResultsViewModel? _viewModel;
	public QuestionnaireResultsPage(ViewQuestionnaireResultsViewModel vm)
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

	private async void ViewRecommendationsButtonClicked(object sender, EventArgs e)
	{
		var vm = ServiceHelper.GetService<ViewQuestionnaireRecommendationsViewModel>();
		await Navigation.PushAsync(new QuestionnaireRecommendationsPage(vm));
	}

}