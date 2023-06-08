using Mapster;
using PizzaManagement.Application.CustomExceptions;
using PizzaManagement.Application.Orders.Requests;
using PizzaManagement.Application.Orders.Responses;
using PizzaManagement.Domain.Orders;
using PizzaManagement.Infrastructure.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Orders
{
    public class OrderService : IOrderService
    {
        readonly IOrderRepository _repo;
        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }
        public async Task CreateAsnyc(CancellationToken cancellationToken, OrderRequestModel order)
        {
            
            var orderToInsert = order.Adapt<Order>();
            var result = await _repo.CreateAsnyc(cancellationToken, orderToInsert);
            if(result == false)
            {
                throw new Exception("Order cant be created, wrong data");
            }
        }

        public async Task<List<OrderResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var listOfOrders = await _repo.GetAllAsync(cancellationToken);

            return listOfOrders.Adapt<List<OrderResponseModel>>();
        }

        public async Task<OrderResponseModel> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _repo.GetByIdAsync(cancellationToken, id);
            if (result == null)
            {
                throw new NotFoundException($"{nameof(Order)} with this Id could not be found in database");
            }
            var isDeleted = await _repo.IsDeleted(cancellationToken, id);
            if (isDeleted)
            {
                throw new ItemIsDeletedException($"{nameof(Order)} is deleted from database");
            }
            return result.Adapt<OrderResponseModel>();
        }
    }
}
