using BracketMaker.Repository;
using BracketMaker.Repository.QuizRepository;
using BracketMaker.Services;
using Microsoft.EntityFrameworkCore;

namespace BracketMaker.AppConfigurationExtensions;

public static class ConfigureDatabaseExtensions
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IGameService, GameService>();
        services.AddDbContext<Context.ItemContext>(opts =>
        {
            opts.UseSqlite(config.GetConnectionString("database"));
        });
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); 
        services.AddScoped<IQuizRepository, QuizRepository>(); 
    }
}