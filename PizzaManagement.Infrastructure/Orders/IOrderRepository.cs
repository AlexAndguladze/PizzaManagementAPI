using PizzaManagement.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Infrastructure.Orders
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetAllAsync(CancellationToken cancellationToken);
        public Task<Order> GetByIdAsync(CancellationToken cancellationToken, int id);
        public Task<bool> CreateAsnyc(CancellationToken cancellationToken, Order order);
        public Task<bool> IsDeleted(CancellationToken cancellationToken, int id);
    }
}
