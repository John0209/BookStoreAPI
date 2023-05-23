using BookStoreAPI.Infracstructure.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Infracstructure.ServiceExtension;

public static class ServiceExtension
{
    public static IServiceCollection AddDIServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DbContextClass>(option =>
        {
            object value = option.UseSqlServer(configuration.GetConnectionString("BookStore"));
        });

        return services;
    }
}
