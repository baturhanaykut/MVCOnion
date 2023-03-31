using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCOnion.Domain.IRepositories;
using MVCOnion.Insfrastructure.ModelContext;
using MVCOnion.Insfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVCOnion.Insfrastructure.Extensions
{
    public static class DependcyInjection
    {

        public static IServiceCollection InfDependencyResolver(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(x =>
            {
                string connectionString = configuration.GetConnectionString(ApplicationDbContext._connectionString);

                x.UseSqlServer(connectionString);
            });

            services.AddScoped<IAuthorRepository, AuthorRepository>()
                    .AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
