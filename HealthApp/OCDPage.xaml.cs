namespace HealthApp;

public partial class OCDPage : ContentPage
{


	public OCDPage()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		//labels set to reccomedations to manage OCD
		string Text1 = "Intrusive thoughts - Try to accpect the intrusive thoughts as the more you try to get rid of them the more they will come into your mind. \nKeep a grounding object with you that you can hold and focus on when you are bothered by your thoughts. \nTry not to attach meaning to these thoughts";
		string Text2 = "Managing compulsions - Try to resist the complusion by; doing an activity to distract yourself, or reacting to intrusive thoughts in a way that doesn't engage with them \nTry to reduce your compulsions so you do them less and less each time \nTry to delay your compulsions more and more, until you no longer need to do them";
		string Text3 = "Distract yourself - Try doing something creative, watch a movie or tv show, or go for a walk \nTry not to wait until you feel ready to distract yourself, try to distract yourself as soon as you feel a compulsion \nWhen doing an activity it can help to say what your doing outloud";
		string Text4 = "Improve your wellbeing - Think about what outside factors affect your OCD, such as; lack of sleep and stress, and try to reduce these \nTry a relaxion technique to improve your wellbeing \nTry to improve your sleep schedule";
	    Label1.Text=Text1;
		Label2.Text=Text2;
		Label3.Text=Text3;
		Label4.Text=Text4;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}

