using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ControleMinutas;

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

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "ControleMinutas.db");

        builder.Services.AddDbContext<Database.AppDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<Database.AppDbContext>();
            db.Database.Migrate();
        }

        return app;
    }
}
