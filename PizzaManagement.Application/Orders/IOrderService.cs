using PizzaManagement.Application.Orders.Requests;
using PizzaManagement.Application.Orders.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Orders
{
    public interface IOrderService
    {
        public Task<List<OrderResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        public Task<OrderResponseModel> GetByIdAsync(CancellationToken cancellationToken, int id);
        public Task CreateAsnyc(CancellationToken cancellationToken, OrderRequestModel order);
    }
}
