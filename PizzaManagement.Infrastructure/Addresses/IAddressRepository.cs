using PizzaManagement.Domain.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Infrastructure.Addresses
{
    public interface IAddressRepository
    {
        public Task<List<Address>> GetAllAsync(CancellationToken cancellationToken);
        public Task<Address> GetByIdAsync(CancellationToken cancellationToken, int id);
        public Task<bool> DeleteAsync(CancellationToken cancellationToken, int id);
        public Task CreateAsnyc(CancellationToken cancellationToken, Address address);
        public Task UpdateAsnyc(CancellationToken cancellationToken, Address address);
        public Task<bool> Exists(CancellationToken cancellationToken, int id);
        public Task<bool> IsDeleted(CancellationToken cancellationToken, int id);
    }
}
