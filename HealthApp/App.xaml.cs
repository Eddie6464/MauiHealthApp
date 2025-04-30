using Microsoft.EntityFrameworkCore;
namespace HealthApp;

public partial class App : Application{   
	public static AppDbContext? Database {get; private set;}
    public static HealthAppService? DatabaseService {get; private set;}
    public static HealthAppViewModel? ViewModel{get; private set;}
	public App()
{
    InitializeComponent();
    
    string dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db");

    Database = new AppDbContext(dbPath);
    Database.Database.Migrate();

    DatabaseService = new HealthAppService(Database);
    ViewModel = new HealthAppViewModel(DatabaseService);

    MainPage = new NavigationPage(new LoginPage());  
}

}
