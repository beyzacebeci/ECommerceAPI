using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Persistance.Concretes;
using ECommerceAPI.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ECommerceAPI.Application.Repositories.Customers;
using ECommerceAPI.Persistance.Repositories.Customers;
using ECommerceAPI.Persistance.Repositories.Orders;
using ECommerceAPI.Application.Repositories.Orders;
using ECommerceAPI.Application.Repositories.Products;
using ECommerceAPI.Persistance.Repositories.Products;

namespace ECommerceAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration) 
        { 
            services.AddSingleton<IProductService, ProductService>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ECommerceAPIDbContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustmerWriteRepository, CustomerWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();



        }
    }
}
