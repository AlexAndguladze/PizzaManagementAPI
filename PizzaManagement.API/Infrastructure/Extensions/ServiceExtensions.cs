using PizzaManagement.Application.Addresses;
using PizzaManagement.Application.Orders;
using PizzaManagement.Application.Pizzas;
using PizzaManagement.Application.Users;
using PizzaManagement.Infrastructure.Addresses;
using PizzaManagement.Infrastructure.Orders;
using PizzaManagement.Infrastructure.Pizzas;
using PizzaManagement.Infrastructure.Users;

namespace PizzaManagement.API.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<IPizzaService, PizzaService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();


        }
    }
}
