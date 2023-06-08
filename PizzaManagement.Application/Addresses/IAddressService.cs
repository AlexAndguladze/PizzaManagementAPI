using PizzaManagement.Application.Addresses.Requests;
using PizzaManagement.Application.Addresses.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Addresses
{
    public interface IAddressService
    {
        public Task<List<AddressResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        public Task<AddressResponseModel> GetByIdAsync(CancellationToken cancellationToken, int id);
        public Task DeleteAsync(CancellationToken cancellationToken, int id);
        public Task CreateAsnyc(CancellationToken cancellationToken, AddressRequestModel address);
        public Task UpdateAsnyc(CancellationToken cancellationToken, AddressRequestModel address, int id);
    }
}
