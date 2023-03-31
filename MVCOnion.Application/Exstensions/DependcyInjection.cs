using Microsoft.Extensions.DependencyInjection;
using MVCOnion.Application.IServices;
using MVCOnion.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVCOnion.Application.Exstensions
{
    public static class DependcyInjection
    {
        public static IServiceCollection AppDependecyResolver(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>()
                .AddScoped<IBookService, BookService>();

            return services;
        }
    }
}
