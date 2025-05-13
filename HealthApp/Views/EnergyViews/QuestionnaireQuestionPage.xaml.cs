namespace EnergyHealthApp.Views;
using EnergyHealthApp.ViewModels;
using EnergyHealthApp.Helpers;

public partial class QuestionnaireQuestionPage : ContentPage
{
	private readonly UpdateQuestionnaireViewModel? _viewModel;

	private List<string> Questions = [
		"On a scale of 1 to 5, how often do you excersize?",
		"On a scale of 1 to 5, how much sleep do you get?",
		"On a scale of 1 to 5, how often do you go to the gym?",
		"On a scale of 1 to 5, how well do you feel on a daily basis?",
		"On a scale of 1 to 5, how often do you walk to work, school, college or university?"
	];
	private int QuestionsIndex = 0;

	private int q1 = 0;
	private int q2 = 0;
	private int q3 = 0;
	private int q4 = 0;
	private int q5 = 0;

	
	public QuestionnaireQuestionPage(UpdateQuestionnaireViewModel vm)
	{
		InitializeComponent();
		_viewModel = vm;
		BindingContext = _viewModel;
	}

	

	private async void QuestionAnswerButtonClicked(Object sender, EventArgs e)
	{
		if (sender is Button button && int.TryParse(button.Text, out int input)){

			if (QuestionsIndex == 0)
			{
				q1 = input;
			}
			else if (QuestionsIndex == 1)
			{
				q2 = input;
			}
			else if (QuestionsIndex == 2)
			{
				q3 = input;
			}
			else if (QuestionsIndex == 3)
			{
				q4 = input;
			}
			else if (QuestionsIndex == 4)
			{
				q5 = input;
			}
		}
		if (QuestionsIndex == 4)
		{
			QuestionsIndex = 0;
			questionLabel.Text = Questions[QuestionsIndex];
			if (_viewModel is not null)
			{
				await _viewModel.UpdateQuestionnaireResults(1, q1, q2, q3, q4, q5);
			}
			var vm = ServiceHelper.GetService<ViewQuestionnaireResultsViewModel>();
			await Navigation.PushAsync(new QuestionnaireResultsPage(vm));
		}
		else
		{
			QuestionsIndex += 1;
			questionLabel.Text = Questions[QuestionsIndex];
		}
	}
}