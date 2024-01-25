using Eshop.Domain.Customers;
using Eshop.Domain.Orders;
using Eshop.Domain.SeedWork;
using Eshop.Infrastructure.Database;
using Eshop.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Eshop.Infrastructure
{
    public static class Registry
    {
        public static void RegistryInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IProductPriceDataApi, ProductPriceDataApi>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEntityTracker, EntityTracker>();

            services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();

            MongoDbSettings mongoDbSettings = configuration.GetSection("MongoDB").Get<MongoDbSettings>() ?? throw new InvalidOperationException();

            services.AddSingleton<IMongoClient>(ServiceProvider =>
            {
                return new MongoClient(mongoDbSettings.ConnectionString);
            });

            services.AddSingleton(provider =>
            {
                return new OrdersContext(mongoDbSettings);
            });
        }
    }
}
