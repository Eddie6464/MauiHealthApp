namespace Nutrition;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell(); // or MainPage = new MainPage();
	}
}