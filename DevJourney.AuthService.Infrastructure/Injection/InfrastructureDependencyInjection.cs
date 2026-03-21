using DevJourney.AuthService.Infrastructure.Configurations;
using DevJourney.AuthService.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;


namespace DevJourney.AuthService.Infrastructure.Injection
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(
                configuration.GetSection("MongoDbSettings"));

            var mongoSettings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();

            if (mongoSettings is null)
                throw new InvalidOperationException("MongoDbSettings não foi configurado.");

            var mongoClient = new MongoClient(mongoSettings.ConnectionString);
            var database = mongoClient.GetDatabase(mongoSettings.DatabaseName);

            services.AddSingleton<IMongoClient>(mongoClient);
            services.AddSingleton(database);

            services.AddScoped<AppDbContext>(_ => AppDbContext.Create(database));

            //services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
