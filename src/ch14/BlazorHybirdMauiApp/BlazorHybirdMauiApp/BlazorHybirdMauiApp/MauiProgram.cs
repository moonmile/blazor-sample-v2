using BlazorHybirdMauiApp.Services;
using BlazorHybirdMauiApp.Shared.Services;
using Microsoft.Extensions.Logging;

namespace BlazorHybirdMauiApp
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
                });

            // Add device-specific services used by the BlazorHybirdMauiApp.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services.AddScoped(
                sp => new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:5000/")
                });
            return builder.Build();
        }
    }
}
