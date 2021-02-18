using Microsoft.Extensions.DependencyInjection;
using Obras.Commom.Repositorie;
using Obras.Commom.Services;
using Obras.Core.Services;
using Obras.Repositories.Connection;
using Obras.Repositories.Repositorie;
using System;


namespace Obras.Services.Configurations
{
    public static class DependeceConfig
    {
        public static void AddDependence(this IServiceCollection services) {

            if (services == null) 
                throw new Exception(nameof(services).ToString());


            //Dependecy injection
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<Context>();
        }
    }
}
