using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MentalHealthApp.Services;
using Microcharts.Maui;

namespace MentalHealthApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMicrocharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

           
            builder.Services.AddSingleton<DatabaseService>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ChatBotPage>();
            builder.Services.AddTransient<ActivitiesPage>();
            builder.Services.AddTransient<EmotionTrackingPage>();


            builder.UseMicrocharts();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
