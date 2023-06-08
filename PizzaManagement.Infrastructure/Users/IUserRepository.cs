using PizzaManagement.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Infrastructure.Users
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
        public Task<User> GetByIdAsync(CancellationToken cancellationToken, int id);
        public Task<bool> DeleteAsync(CancellationToken cancellationToken, int id);
        public Task CreateAsnyc(CancellationToken cancellationToken, User user);
        public Task UpdateAsnyc(CancellationToken cancellationToken, User user);
        public Task<bool> Exists(CancellationToken cancellationToken, int id);
        public Task<bool> IsDeleted(CancellationToken cancellationToken, int id);
    }
}
