using PizzaManagement.Application.Users.Requests;
using PizzaManagement.Application.Users.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Users
{
    public interface IUserService
    {
        public Task<List<UserResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        public Task<UserResponseModel> GetByIdAsync(CancellationToken cancellationToken, int id);
        public Task DeleteAsync(CancellationToken cancellationToken, int id);
        public Task CreateAsnyc(CancellationToken cancellationToken, UserRequestModel user);
        public Task UpdateAsnyc(CancellationToken cancellationToken, UserRequestModel user, int id);
    }
}
