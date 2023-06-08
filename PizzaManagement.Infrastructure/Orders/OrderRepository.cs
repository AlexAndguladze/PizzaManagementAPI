using Microsoft.EntityFrameworkCore;
using PizzaManagement.Domain.Orders;
using PizzaManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Infrastructure.Orders
{
    public class OrderRepository : IOrderRepository
    {
        readonly PizzaManagerDbContext _context;

        public OrderRepository(PizzaManagerDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<bool> CreateAsnyc(CancellationToken cancellationToken, Order order)
        {
            var userExists=await _context.Users.AnyAsync(u => u.Id == order.UserId);
            var AddressExists= await _context.Addresses.AnyAsync(a => a.Id == order.AddressId);
            var PizzaExists = await _context.Addresses.AnyAsync(a => a.Id == order.PizzaId);
            //უკეთესი გზის პოვნაც შეიძლება
            var userHasGivenAddress = await _context.Addresses.Where(a => a.Id == order.AddressId).AnyAsync(a=>a.UserId==order.UserId);
            if ((userExists || AddressExists || PizzaExists || !userHasGivenAddress) == false) { 
                return false;
            }

            await _context.AddAsync(order);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Orders.Select(o => o).Where(o => o.IsDeleted == false).ToListAsync(cancellationToken);
        }

        public async Task<Order> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(a => a.Id == id);

            return result;
        }

        public Task<bool> IsDeleted(CancellationToken cancellationToken, int id)
        {
            throw new NotImplementedException();
        }
    }
}
