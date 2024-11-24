using Refit;
using Lab9.Services;

namespace Lab9;

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

        // Реєстрація API
        builder.Services.AddRefitClient<IBankApi>()
                        .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:5211"));

        builder.Services.AddRefitClient<ICardholderApi>()
                        .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:5211"));

        return builder.Build();
    }
}
