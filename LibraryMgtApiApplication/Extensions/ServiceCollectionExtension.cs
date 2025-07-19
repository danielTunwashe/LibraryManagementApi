
using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryMgtApiApplication.Middlewares;
using LibraryMgtApiDomain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryMgtApiApplication.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionExtension).Assembly;

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));

            services.AddAutoMapper(applicationAssembly);

            services.AddTransient<ErrorHandlingMiddleware>();


            services.AddValidatorsFromAssembly(applicationAssembly).AddFluentValidationAutoValidation();

        }
    }
}
