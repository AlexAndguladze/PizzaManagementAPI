using Mapster;
using PizzaManagement.Application.Addresses.Requests;
using PizzaManagement.Application.Addresses.Responses;
using PizzaManagement.Application.CustomExceptions;
using PizzaManagement.Domain.Addresses;
using PizzaManagement.Infrastructure.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Addresses
{
    public class AddressService : IAddressService
    {
        readonly IAddressRepository _repo;
        public AddressService(IAddressRepository repo)
        {
            _repo = repo;
        }
        public async Task CreateAsnyc(CancellationToken cancellationToken, AddressRequestModel address)
        {
            var addressToInsert = address.Adapt<Address>();
            await _repo.CreateAsnyc(cancellationToken, addressToInsert);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var isDeleted = await _repo.IsDeleted(cancellationToken, id);
            if (isDeleted)
            {
                throw new ItemIsDeletedException($"{nameof(Address)} is Already deleted from database");
            }
            var result = await _repo.DeleteAsync(cancellationToken, id);
            if (result == false)
            {
                throw new NotFoundException($"{nameof(Address)} could not be found in database");
            }
        }

        public async Task<List<AddressResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var listOfAddresses = await _repo.GetAllAsync(cancellationToken);

            return listOfAddresses.Adapt<List<AddressResponseModel>>();
        }

        public async Task<AddressResponseModel> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _repo.GetByIdAsync(cancellationToken, id);
            if (result == null)
            {
                throw new NotFoundException($"{nameof(Address)} with this Id could not be found in database");
            }
            var isDeleted = await _repo.IsDeleted(cancellationToken, id);
            if (isDeleted)
            {
                throw new ItemIsDeletedException($"{nameof(Address)} is deleted from database");
            }
            return result.Adapt<AddressResponseModel>();
        }

        public async Task UpdateAsnyc(CancellationToken cancellationToken, AddressRequestModel user, int id)
        {
            var exists = await _repo.Exists(cancellationToken, id);
            if (exists == false)
            {
                throw new NotFoundException($"{nameof(Address)} could not be found in database");
            }
            var isDeleted = await _repo.IsDeleted(cancellationToken, id);
            if (isDeleted)
            {
                throw new ItemIsDeletedException($"{nameof(Address)} is deleted from database");
            }
            var pizzaToUpdate = user.Adapt<Address>();
            pizzaToUpdate.Id = id;
            await _repo.UpdateAsnyc(cancellationToken, pizzaToUpdate);
        }
    }
}
