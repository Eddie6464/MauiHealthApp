namespace HealthApp;

public partial class Question3Page : ContentPage
{
	List<int> list3;
	string username8;

	public Question3Page(List<int> list, string username)
	{
		InitializeComponent();
	    NavigationPage.SetHasNavigationBar(this, false);
		list3 = list;
		username8=username;
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		OneBtn.BackgroundColor = Colors.MediumPurple;
		TwoBtn.BackgroundColor = Colors.MediumPurple;
		ThreeBtn.BackgroundColor = Colors.MediumPurple;
		FourBtn.BackgroundColor = Colors.MediumPurple;
		FiveBtn.BackgroundColor = Colors.MediumPurple;
		Navigation.PopAsync();
	}

	private void OnQuestion4Click(object sender, EventArgs e)
	{   
		if (OneBtn.BackgroundColor == Colors.DarkOrchid){
			list3.Add(1);
		};
		if (TwoBtn.BackgroundColor == Colors.DarkOrchid){
			list3.Add(2);
		};
		if (ThreeBtn.BackgroundColor == Colors.DarkOrchid){
			list3.Add(3);
		};
		if (FourBtn.BackgroundColor == Colors.DarkOrchid){
			list3.Add(4);
		};
		if (FiveBtn.BackgroundColor == Colors.DarkOrchid){
			list3.Add(5);
		};
		OneBtn.BackgroundColor = Colors.MediumPurple;
		TwoBtn.BackgroundColor = Colors.MediumPurple;
		ThreeBtn.BackgroundColor = Colors.MediumPurple;
		FourBtn.BackgroundColor = Colors.MediumPurple;
		FiveBtn.BackgroundColor = Colors.MediumPurple;
		Navigation.PushAsync(new Question4Page(list3, username8));
	}

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

