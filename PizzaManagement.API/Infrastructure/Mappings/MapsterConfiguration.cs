using Mapster;
using PizzaManagement.Application.Addresses.Requests;
using PizzaManagement.Application.Addresses.Responses;
using PizzaManagement.Application.Orders.Requests;
using PizzaManagement.Application.Orders.Responses;
using PizzaManagement.Application.Pizzas.Responses;
using PizzaManagement.Application.Users.Requests;
using PizzaManagement.Application.Users.Responses;
using PizzaManagement.Domain.Addresses;
using PizzaManagement.Domain.Orders;
using PizzaManagement.Domain.Pizzas;
using PizzaManagement.Domain.Users;

namespace PizzaManagement.API.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<Pizza, PizzaResponseModel>.NewConfig().TwoWays();
            TypeAdapterConfig<Pizza, PizzaByIdResponseModel>.NewConfig().TwoWays();

            TypeAdapterConfig<Order, OrderResponseModel>.NewConfig().TwoWays();
            TypeAdapterConfig<Order, OrderRequestModel>.NewConfig().TwoWays();

            TypeAdapterConfig<User, UserRequestModel>.NewConfig().TwoWays();
            TypeAdapterConfig<User, UserResponseModel>.NewConfig().TwoWays();

            TypeAdapterConfig<Address, AddressRequestModel>.NewConfig().TwoWays();
            TypeAdapterConfig<Address, AddressResponseModel>.NewConfig().TwoWays();


        }
    }
}
