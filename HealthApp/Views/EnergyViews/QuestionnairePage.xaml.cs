using EnergyHealthApp.ViewModels;
using EnergyHealthApp.Helpers;

namespace EnergyHealthApp.Views;

public partial class QuestionnairePage : ContentPage
{
	public QuestionnairePage()
	{
		InitializeComponent();
	}

	private async void HomeButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EnergyMainPage());
	}

	private async void NewQuestionnaireButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new QuestionnaireStartPage());
	}

	private async void ViewResultsButtonClicked(object sender, EventArgs e)
	{
		var vm = ServiceHelper.GetService<ViewQuestionnaireResultsViewModel>();
		await Navigation.PushAsync(new QuestionnaireResultsPage(vm));
	}
}