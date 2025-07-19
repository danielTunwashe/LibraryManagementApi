using LibraryMgtApiDomain.Repositories;
using LibraryMgtApiInfrastructure.DataAccess;
using LibraryMgtApiInfrastructure.Repositories;
using LibraryMgtApiInfrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryMgtApiInfrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // This method is used to add the infrastructure services to the IServiceCollection.
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // This method configures the DbContext for the application.
            var connectionString = configuration.GetConnectionString("LibraryMgtDbContext");
            // It adds the LibraryMgtDbContext to the service collection with SQL Server as the database provider.
            services.AddDbContext<LibraryMgtDbContext>(options =>
            {
                options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ILibraryMgtSeeder, LibraryMgtSeeder>();


        }
    }
}
