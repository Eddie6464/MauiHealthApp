using Microsoft.Extensions.Logging;
using Nutrition.Services;
using Nutrition.Views;
using Nutrition.ViewModel;


namespace Nutrition;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		
		// Register the database service

		 builder.Services.AddSingleton<DatabaseService>();

		// Register the pages
		builder.Services.AddTransient<CalorieCounter>();
        builder.Services.AddSingleton<CalorieCounterViewModel>();
		

		#if DEBUG
				builder.Logging.AddDebug();
		#endif

				return builder.Build();
			}
}
