using Microsoft.Extensions.Logging;
using BirdWatchingMaui.Services;
using CommunityToolkit.Maui;

namespace BirdWatchingMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<IAzureService, AzureService>();
        builder.Services.AddSingleton<BirdSightingsViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<BirdDetailsPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

