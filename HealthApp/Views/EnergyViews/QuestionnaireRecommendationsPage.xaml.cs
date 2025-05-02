namespace EnergyHealthApp.Views;
using EnergyHealthApp.ViewModels;

public partial class QuestionnaireRecommendationsPage : ContentPage
{
	private readonly ViewQuestionnaireRecommendationsViewModel _viewModel;
	public QuestionnaireRecommendationsPage(ViewQuestionnaireRecommendationsViewModel vm)
	{
		InitializeComponent();
		_viewModel = vm;
		BindingContext = _viewModel;
	}

	private async void HomeButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EnergyMainPage());
	}

	protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadRecommendations(1); // assumes user with id 1
    }

}