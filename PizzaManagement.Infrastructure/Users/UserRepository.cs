using Microsoft.EntityFrameworkCore;
using PizzaManagement.Domain.Users;
using PizzaManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        readonly PizzaManagerDbContext _context;

        public UserRepository(PizzaManagerDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task CreateAsnyc(CancellationToken cancellationToken, User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var userToBeDeleted = await GetByIdAsync(cancellationToken, id);
            if (userToBeDeleted == null)
            {
                return false;
            }
            userToBeDeleted.IsDeleted = true;
            _context.Users.Update(userToBeDeleted);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Users.Select(u => u).Where(u => u.IsDeleted == false).ToListAsync(cancellationToken);
        }

        public async Task<User> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return result;
        }

        public async Task UpdateAsnyc(CancellationToken cancellationToken, User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            return await _context.Pizzas.AnyAsync(u => u.Id == id);
        }

        public async Task<bool> IsDeleted(CancellationToken cancellationToken, int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return result.IsDeleted;
        }
    }
}
