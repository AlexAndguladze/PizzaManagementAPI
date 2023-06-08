using Microsoft.EntityFrameworkCore;
using PizzaManagement.Domain.Addresses;
using PizzaManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Infrastructure.Addresses
{
    public class AddressRepository : IAddressRepository
    {
        readonly PizzaManagerDbContext _context;

        public AddressRepository(PizzaManagerDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task CreateAsnyc(CancellationToken cancellationToken, Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var AddressToBeDeleted = await GetByIdAsync(cancellationToken, id);
            if (AddressToBeDeleted == null)
            {
                return false;
            }
            AddressToBeDeleted.IsDeleted = true;
            _context.Addresses.Update(AddressToBeDeleted);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<Address>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Addresses.Select(a => a).Where(a => a.IsDeleted == false).ToListAsync(cancellationToken);
        }

        public async Task<Address> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);

            return result;
        }

        public async Task UpdateAsnyc(CancellationToken cancellationToken, Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            return await _context.Addresses.AnyAsync(a => a.Id == id);
        }

        public async Task<bool> IsDeleted(CancellationToken cancellationToken, int id)
        {
            var result = await _context.Addresses.FirstOrDefaultAsync(u => u.Id == id);
            return result.IsDeleted;
        }
    }
}
