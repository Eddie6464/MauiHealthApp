using System.Net.Security;
using Microsoft.EntityFrameworkCore;

namespace HealthApp;

public partial class Question6Page : ContentPage
{
	List<int> list6;
	string username11;

	private readonly HealthAppViewModel _viewModel; 


	public Question6Page(List<int> list, string username)
	{
		InitializeComponent();
	    NavigationPage.SetHasNavigationBar(this, false);
		_viewModel = App.ViewModel;
        BindingContext = _viewModel;
		//gets username and list from previous page
		list6=list;
		username11=username;
	}

    //resets button colours
	private void OnBackClick(object sender, EventArgs e)
	{
		OneBtn.BackgroundColor = Colors.MediumPurple;
		TwoBtn.BackgroundColor = Colors.MediumPurple;
		ThreeBtn.BackgroundColor = Colors.MediumPurple;
		FourBtn.BackgroundColor = Colors.MediumPurple;
		FiveBtn.BackgroundColor = Colors.MediumPurple;
		Navigation.PopAsync();
	}

    //when user goes to next page button colours reset, and choice is added to the list
	private async void OnQuestionaireEndClick(object sender, EventArgs e)
	{   
		if (OneBtn.BackgroundColor == Colors.DarkOrchid){
			list6.Add(1);
		};
		if (TwoBtn.BackgroundColor == Colors.DarkOrchid){
			list6.Add(2);
		};
		if (ThreeBtn.BackgroundColor == Colors.DarkOrchid){
			list6.Add(3);
		};
		if (FourBtn.BackgroundColor == Colors.DarkOrchid){
			list6.Add(4);
		};
		if (FiveBtn.BackgroundColor == Colors.DarkOrchid){
			list6.Add(5);
		};
		OneBtn.BackgroundColor = Colors.MediumPurple;
		TwoBtn.BackgroundColor = Colors.MediumPurple;
		ThreeBtn.BackgroundColor = Colors.MediumPurple;
		FourBtn.BackgroundColor = Colors.MediumPurple;
		FiveBtn.BackgroundColor = Colors.MediumPurple;

        //Database
		//await _viewModel.AddQuestions(await _viewModel.FetchUserId(username11), list6[0], list6[1], list6[2], list6[3], list6[4], list6[0]);

		Navigation.PushAsync(new QuestionaireEndPage(list6, username11));
	    }

    //changes button colour when a button is clicked
	private void On1Click(object sender, EventArgs e)
	{
		OneBtn.BackgroundColor = Colors.DarkOrchid;
		TwoBtn.BackgroundColor = Colors.MediumPurple;
		ThreeBtn.BackgroundColor = Colors.MediumPurple;
		FourBtn.BackgroundColor = Colors.MediumPurple;
		FiveBtn.BackgroundColor = Colors.MediumPurple;
	}

	private void On2Click(object sender, EventArgs e)
	{
		TwoBtn.BackgroundColor = Colors.DarkOrchid;
		OneBtn.BackgroundColor = Colors.MediumPurple;
		ThreeBtn.BackgroundColor = Colors.MediumPurple;
		FourBtn.BackgroundColor = Colors.MediumPurple;
		FiveBtn.BackgroundColor = Colors.MediumPurple;
	}

    private void On3Click(object sender, EventArgs e)
	{
		ThreeBtn.BackgroundColor = Colors.DarkOrchid;
		TwoBtn.BackgroundColor = Colors.MediumPurple;
		OneBtn.BackgroundColor = Colors.MediumPurple;
		FourBtn.BackgroundColor = Colors.MediumPurple;
		FiveBtn.BackgroundColor = Colors.MediumPurple;
	}

    private void On4Click(object sender, EventArgs e)
	{
		FourBtn.BackgroundColor = Colors.DarkOrchid;
		TwoBtn.BackgroundColor = Colors.MediumPurple;
		ThreeBtn.BackgroundColor = Colors.MediumPurple;
		OneBtn.BackgroundColor = Colors.MediumPurple;
		FiveBtn.BackgroundColor = Colors.MediumPurple;
	}

    private void On5Click(object sender, EventArgs e)
	{
		FiveBtn.BackgroundColor = Colors.DarkOrchid;
		TwoBtn.BackgroundColor = Colors.MediumPurple;
		ThreeBtn.BackgroundColor = Colors.MediumPurple;
		FourBtn.BackgroundColor = Colors.MediumPurple;
		OneBtn.BackgroundColor = Colors.MediumPurple;
	}
}

