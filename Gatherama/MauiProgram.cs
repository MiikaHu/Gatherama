using Gatherama.Data;
using Gatherama.Services;
using Gatherama.Shared;
using Microsoft.Extensions.Logging;

namespace Gatherama
{
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
                })
                .UseMauiMaps();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddTransient<ApiService>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("Replace with your azure web app url") }); //Add your azure web app url
            builder.Services.AddSingleton<LoginState>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();
            
            return builder.Build();
        }
    }
}