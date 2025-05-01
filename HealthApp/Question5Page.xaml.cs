namespace HealthApp;

public partial class Question5Page : ContentPage
{
	
    public static HealthAppViewModel? ViewModel{get; private set;}
	List<int> list5;
	string username10;

	public Question5Page(List<int> list, string username)
	{
		InitializeComponent();
	    NavigationPage.SetHasNavigationBar(this, false);
		//gets username and list from previous page
        list5 = list;
		username10=username;
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
	private void OnQuestion6Click(object sender, EventArgs e)
	{   
		if (OneBtn.BackgroundColor == Colors.DarkOrchid){
			list5.Add(1);
		};
		if (TwoBtn.BackgroundColor == Colors.DarkOrchid){
			list5.Add(2);
		};
		if (ThreeBtn.BackgroundColor == Colors.DarkOrchid){
			list5.Add(3);
		};
		if (FourBtn.BackgroundColor == Colors.DarkOrchid){
			list5.Add(4);
		};
		if (FiveBtn.BackgroundColor == Colors.DarkOrchid){
			list5.Add(5);
		};
		OneBtn.BackgroundColor = Colors.MediumPurple;
		TwoBtn.BackgroundColor = Colors.MediumPurple;
		ThreeBtn.BackgroundColor = Colors.MediumPurple;
		FourBtn.BackgroundColor = Colors.MediumPurple;
		FiveBtn.BackgroundColor = Colors.MediumPurple;
		Navigation.PushAsync(new Question6Page(list5, username10));
	}

    //changes button colours when button is clicked
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

