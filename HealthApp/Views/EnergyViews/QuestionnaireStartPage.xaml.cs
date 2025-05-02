namespace EnergyHealthApp.Views;
using EnergyHealthApp.Helpers;
using EnergyHealthApp.ViewModels;

public partial class QuestionnaireStartPage : ContentPage
{
	public QuestionnaireStartPage()
	{
		InitializeComponent();
	}

	private async void HomeButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new EnergyMainPage());
		}
		
	private async void NewQuestionnaireButtonClicked(object sender, EventArgs e)
	{
		var vm = ServiceHelper.GetService<UpdateQuestionnaireViewModel>();
		await Navigation.PushAsync(new QuestionnaireQuestionPage(vm));
	}

}