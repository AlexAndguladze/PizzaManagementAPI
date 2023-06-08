using Microsoft.AspNetCore.Mvc;
using PizzaManagement.API.Infrastructure.Models.ExampleModels;
using PizzaManagement.Application.Users;
using PizzaManagement.Application.Users.Requests;
using PizzaManagement.Application.Users.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        /// <summary>
        /// Returns all users from database
        /// </summary>
        [HttpGet]
        public async Task<List<UserResponseModel>> GetAll(CancellationToken cancellation)
        {
            return await _service.GetAllAsync(cancellation);
        }
        /// <summary>
        /// Gets specified user from database
        /// </summary>
        [HttpGet("{id}")]
        public async Task<UserResponseModel> GetById(CancellationToken cancellationToken, int id)
        {
            return await _service.GetByIdAsync(cancellationToken, id);
        }
        /// <summary>
        /// Creates user and saves it to database
        /// </summary>
        /// 
        [SwaggerRequestExample(typeof(UserRequestModel), typeof(UserCreateExample))]
        [HttpPost]
        public async Task Create(CancellationToken cancellationToken, UserRequestModel request)
        {
            await _service.CreateAsnyc(cancellationToken, request);
        }
        /// <summary>
        /// Updates specified user's information
        /// </summary>
        [HttpPut("{id}")]
        public async Task Update(CancellationToken cancellationToken, UserRequestModel request, int id)
        {
            await _service.UpdateAsnyc(cancellationToken, request, id);
        }
        /// <summary>
        /// Deletes specified user from database
        /// </summary>
        [HttpDelete("{id}")]
        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            await _service.DeleteAsync(cancellationToken, id);
        }
    }
}
