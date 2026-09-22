using ControleMinutas.Database.Repositories;
using ControleMinutas.Entities;
using ControleMinutas.Interfaces.Repositories;
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

        builder.Services.AddTransient<IReadRepository<Trabalho>, ReadRepository<Trabalho>>();
        builder.Services.AddTransient<IWriteRepository<Trabalho>, WriteRepository<Trabalho>>();
        builder.Services.AddTransient<IReadRepository<Minuta>, ReadRepository<Minuta>>();
        builder.Services.AddTransient<IWriteRepository<Minuta>, WriteRepository<Minuta>>();
        builder.Services.AddTransient<IReadRepository<Empresa>, ReadRepository<Empresa>>();
        builder.Services.AddTransient<IWriteRepository<Empresa>, WriteRepository<Empresa>>();
        builder.Services.AddTransient<IReadRepository<Terminal>, ReadRepository<Terminal>>();
        builder.Services.AddTransient<IWriteRepository<Terminal>, WriteRepository<Terminal>>();

        builder.Services.AddTransient<UseCases.TrabalhoUseCases>();
        builder.Services.AddTransient<UseCases.MinutaUseCases>();




        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<Database.AppDbContext>();
            db.Database.Migrate();
        }

        return app;
    }
}
