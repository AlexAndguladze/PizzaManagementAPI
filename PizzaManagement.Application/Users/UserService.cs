using Mapster;
using PizzaManagement.Application.CustomExceptions;
using PizzaManagement.Application.Users.Requests;
using PizzaManagement.Application.Users.Responses;
using PizzaManagement.Domain.Users;
using PizzaManagement.Infrastructure.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task CreateAsnyc(CancellationToken cancellationToken, UserRequestModel user)
        {
            var pizzaToInsert = user.Adapt<User>();
            await _repo.CreateAsnyc(cancellationToken, pizzaToInsert);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var isDeleted = await _repo.IsDeleted(cancellationToken, id);
            if (isDeleted)
            {
                throw new ItemIsDeletedException($"{nameof(User)} is Already deleted from database");
            }
            var result = await _repo.DeleteAsync(cancellationToken, id);
            if (result == false)
            {
                throw new NotFoundException($"{nameof(User)} could not be found in database");
            }
        }

        public async Task<List<UserResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var listOfUsers = await _repo.GetAllAsync(cancellationToken);

            return listOfUsers.Adapt<List<UserResponseModel>>();
        }

        public async Task<UserResponseModel> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _repo.GetByIdAsync(cancellationToken, id);
            if (result == null)
            {
                throw new NotFoundException($"{nameof(User)} with this Id could not be found in database");
            }
            var isDeleted = await _repo.IsDeleted(cancellationToken, id);
            if (isDeleted)
            {
                throw new ItemIsDeletedException($"{nameof(User)} is deleted from database");
            }
            return result.Adapt<UserResponseModel>();
        }

        public async Task UpdateAsnyc(CancellationToken cancellationToken, UserRequestModel user, int id)
        {
            var exists = await _repo.Exists(cancellationToken, id);
            if (exists == false)
            {
                throw new NotFoundException($"{nameof(User)} could not be found in database");
            }
            var isDeleted = await _repo.IsDeleted(cancellationToken, id);
            if (isDeleted)
            {
                throw new ItemIsDeletedException($"{nameof(User)} is deleted from database");
            }
            var pizzaToUpdate = user.Adapt<User>();
            pizzaToUpdate.Id = id;
            await _repo.UpdateAsnyc(cancellationToken, pizzaToUpdate);
        }
    }
}
