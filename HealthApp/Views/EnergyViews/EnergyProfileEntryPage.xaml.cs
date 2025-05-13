using System.Text.RegularExpressions;
using EnergyHealthApp.ViewModels;
using EnergyHealthApp.Helpers;
namespace EnergyHealthApp.Views;



public partial class EnergyProfileEntryPage : ContentPage
{
	private readonly UpdateEnergyProfileViewModel? _viewModel;

	private List<string> Questions = 
	["What is your heart rate?", 
	"What is your blood pressure?", 
	"What is your respiratory rate"];

	private int QuestionsIndex = 0;

	public EnergyProfileEntryPage(UpdateEnergyProfileViewModel vm)
	{
		InitializeComponent();
		_viewModel = vm;
		BindingContext = _viewModel;
	}

	private async void HomeButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EnergyMainPage());
	}

	private async void ConfirmButtonClicked(object sender, EventArgs e)
	{
		string input = dataEntry.Text;
		errorLabel.IsVisible = false;
		
		if (QuestionsIndex == 0)
		{
			HandleHeartRate(input);
		}
		else if (QuestionsIndex == 1)
		{
			HandleBloodPressure(input);
		}
		else if (QuestionsIndex == 2)
		{
			HandleRespiratoryRate(input);
		}
		if (QuestionsIndex <Questions.Count)
		{
			string newQuestionText = Questions[QuestionsIndex];
			questionText.Text = newQuestionText;
		}
		else
		{
			QuestionsIndex = 0;
			string newQuestionText = Questions[QuestionsIndex]; 
			questionText.Text = newQuestionText;
			var vm = ServiceHelper.GetService<ViewEnergyProfileViewModel>();
			await Navigation.PushAsync(new EnergyProfilePage(vm));
		}
		
	}
	private async void SkipButtonClicked(object sender, EventArgs e)
	{
		dataEntry.Text = "";
		QuestionsIndex += 1;
		errorLabel.IsVisible = false;
		if (QuestionsIndex <Questions.Count)
		{
			string newQuestionText = Questions[QuestionsIndex];
			questionText.Text = newQuestionText;

		}
		else
		{
			QuestionsIndex = 0;
			string newQuestionText = Questions[QuestionsIndex]; 
			questionText.Text = newQuestionText;
			var vm = ServiceHelper.GetService<ViewEnergyProfileViewModel>();
			await Navigation.PushAsync(new EnergyProfilePage(vm));
		}
	}

	private async void HandleHeartRate(string input)
	{
		if (!int.TryParse(input, out int result))
		{
			errorLabel.Text = "Please enter a valid integer for heart rate!";
			errorLabel.IsVisible = true;
			return; 
		}

		if (result < 30 || result > 200)
		{
			errorLabel.Text = "Please enter a realistic heart rate between 30 and 200 bpm.";
			errorLabel.IsVisible = true;
			return; 
		}

		if (_viewModel is not null)
		{
			await _viewModel.UpdateHeartRate(1, result);
		}

		QuestionsIndex += 1;
		dataEntry.Text = "";
	}

	
	private async void HandleBloodPressure(string input)
	{
		string pattern = @"^(\d{2,3})\/(\d{2,3})$"; 

		Match match = Regex.Match(input, pattern);

		if (!match.Success) // Checks if the input matches the valid input (integer/integer)
		{
			errorLabel.Text = "Please enter a value in the format number/number with numbers between 2 and 3 digits";
			errorLabel.IsVisible = true;
			return;
		}

		int systolic = int.Parse(match.Groups[1].Value);
		int diastolic = int.Parse(match.Groups[2].Value);

		if (systolic < 70 || systolic > 250 || diastolic < 40 || diastolic > 150)
		{
			errorLabel.Text = "Please enter suitable values in the following ranges: (Systolic: 70–250, Diastolic: 40–150).";
			errorLabel.IsVisible = true;
			return;
		}

		if (systolic <= diastolic)
		{
			errorLabel.Text = "Systolic reading must be greater than diastolic reading.";
			errorLabel.IsVisible = true;
			return;
		}

		errorLabel.IsVisible = false;

		if (_viewModel is not null)
		{
			await _viewModel.UpdateBloodPressure(1, input);
		}

		QuestionsIndex += 1;
		dataEntry.Text = "";
	}


	private async void HandleRespiratoryRate(string input)
	{
		if (!int.TryParse(input, out int result))
		{
			errorLabel.Text = "Please enter an integer for respiratory rate!";
			errorLabel.IsVisible = true;
			return; 
		}

		if (result < 6 || result > 50)
		{
			errorLabel.Text = "Please enter a realistic number for respiratory rate between 6 and 50.";
			errorLabel.IsVisible = true;
			return;
		}

		errorLabel.IsVisible = false;

		if (_viewModel is not null)
		{
			await _viewModel.UpdateRespiratoryRate(1, result);
		}

		QuestionsIndex += 1;
		dataEntry.Text = "";
	}

}