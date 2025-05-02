namespace EnergyHealthApp.Views;
using EnergyHealthApp.Helpers;
using EnergyHealthApp.ViewModels;

public partial class EnergyMainPage : ContentPage
{
	public EnergyMainPage()
	{
		InitializeComponent();
	}

	private async void OverviewButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new OverviewPage());
	}
	private async void QuestionnaireButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new QuestionnairePage());
	}
	private async void GlossaryButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new GlossaryPage());
	}
	private async void EnergyProfileButtonClicked(object sender, EventArgs e)
	{
		var vm = ServiceHelper.GetService<ViewEnergyProfileViewModel>();
		await Navigation.PushAsync(new EnergyProfilePage(vm));
	}
	private async void StepsTrackerButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new StepsTrackerPage());
	}
}

