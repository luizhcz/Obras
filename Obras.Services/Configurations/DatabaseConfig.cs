using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Obras.Repositories.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obras.Services.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
