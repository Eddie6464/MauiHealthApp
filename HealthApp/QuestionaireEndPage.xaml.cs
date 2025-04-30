namespace HealthApp;

public partial class QuestionaireEndPage : ContentPage
{
	private readonly HealthAppViewModel _viewModel; 
	string username12;

	List<int> list7;

	public QuestionaireEndPage(List<int> list, string username)
	{
		InitializeComponent();
	    NavigationPage.SetHasNavigationBar(this, false);
		_viewModel = App.ViewModel;
        BindingContext = _viewModel;
		list7=list;
		username12=username;
	}

	private async void OnQuestionaireEndClick (object sender, EventArgs e)
	{   
		
		// if(await _viewModel.GetQuestion1(username12, await _viewModel.GetQuestionaireId())>3){
		// 	String text1 = "Include methods to reduce stress in plan";
		//  Q1.Text = text1;
		// }
		// if(await _viewModel.GetQuestion1(username12, await _viewModel.GetQuestionaireId())==3){
		// 	String text2 = "Could include methods to reduce stress in plan";
		//  Q1.Text = text2;
		// }
		// if(await _viewModel.GetQuestion2(username12, await _viewModel.GetQuestionaireId())>3){
		// 	String text3 = "Inlclude include methods to improve sleep, such as a sleep schedule in plan";
		//  Q2.Text = text3;
		// }
		// if(await _viewModel.GetQuestion2(username12, await _viewModel.GetQuestionaireId())==3){
		// 	String text4 = "Could include methods to improve sleep, such as a sleep schedule in plan";
		//  Q2.Text = text4;
		// }
		// if(await _viewModel.GetQuestion3(username12, await _viewModel.GetQuestionaireId())>3){
		// 	String text5 = "Include methods to distract your mind from overthinking in plan";
		//  Q3.Text = text5;
		// }
		// if(await _viewModel.GetQuestion3(username12, await _viewModel.GetQuestionaireId())==3){
		// 	String text6 = "Could include methods to distract your mind from overthinking in plan";
		//  Q3.Text = text6;
		// }
		// if(await _viewModel.GetQuestion4(username12, await _viewModel.GetQuestionaireId())>3){
		// 	String text7 = "Include methods to improve your diet in plan";
		//  Q4.Text = text7;
		// }
		// if(await _viewModel.GetQuestion4(username12, await _viewModel.GetQuestionaireId())==3){
		// 	String text8 = "Could include methods to improve your diet in plan";
		//  Q4.Text = text8;
		// }
		// if(await _viewModel.GetQuestion5(username12, await _viewModel.GetQuestionaireId())>3){
		// 	String text9 = "Include methods to increase water intake in plan";
		//  Q5.Text = text9;
		// }
		// if(await _viewModel.GetQuestion5(username12, await _viewModel.GetQuestionaireId())==3){
		// 	String text10 = "Could include methods to increase water intake in plan";
		//  Q5.Text = text10;
		// }
		// if(await _viewModel.GetQuestion6(username12, await _viewModel.GetQuestionaireId())>3){
		// 	String text12 = "Could include methods to get out in nature more in plan";
		//  Q6.Text = text12;
		// }
		// if(await _viewModel.GetQuestion6(username12, await _viewModel.GetQuestionaireId())==3){
		// 	String text12 = "Could include methods to get out in nature more in plan";
		//  Q6.Text = text12;
		// }
		if(list7[0]>3){
			String text1 = "Include methods to reduce stress in plan";
		 Q1.Text = text1;
		}
		if(list7[0]==3){
			String text2 = "Could include methods to reduce stress in plan";
		 Q1.Text = text2;
		}
		if(list7[1]>3){
			String text3 = "Inlclude include methods to improve sleep, such as a sleep schedule in plan";
		 Q2.Text = text3;
		}
		if(list7[1]==3){
			String text4 = "Could include methods to improve sleep, such as a sleep schedule in plan";
		 Q2.Text = text4;
		}
		if(list7[2]>3){
			String text5 = "Include methods to distract your mind from overthinking in plan";
		 Q3.Text = text5;
		}
		if(list7[2]==3){
			String text6 = "Could include methods to distract your mind from overthinking in plan";
		 Q3.Text = text6;
		}
		if(list7[3]>3){
			String text7 = "Include methods to improve your diet in plan";
		 Q4.Text = text7;
		}
		if(list7[3]==3){
			String text8 = "Could include methods to improve your diet in plan";
		 Q4.Text = text8;
		}
		if(list7[4]>3){
			String text9 = "Include methods to increase water intake in plan";
		 Q5.Text = text9;
		}
		if(list7[4]==3){
			String text10 = "Could include methods to increase water intake in plan";
		 Q5.Text = text10;
		}
		if(list7[5]>3){
			String text12 = "Could include methods to get out in nature more in plan";
		 Q6.Text = text12;
		}
		if(list7[5]==3){
			String text12 = "Could include methods to get out in nature more in plan";
		 Q6.Text = text12;
		}

        else{
			String text13 = "Nothing recommened to include in plan";
			Q1.Text = text13;
		}
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnMakingPlansClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MakingPlansPage(username12));
	}

	
}

