using Microsoft.AspNetCore.Mvc;
using PizzaManagement.Application.Addresses;
using PizzaManagement.Application.Addresses.Requests;
using PizzaManagement.Application.Addresses.Responses;

namespace PizzaManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }
        /// <summary>
        /// Returns all addresses from database
        /// </summary>
        [HttpGet]
        public async Task<List<AddressResponseModel>> GetAll(CancellationToken cancellation)
        {
            return await _service.GetAllAsync(cancellation);
        }
        /// <summary>
        /// Gets specified address from database
        /// </summary>
        [HttpGet("{id}")]
        public async Task<AddressResponseModel> GetById(CancellationToken cancellationToken, int id)
        {
            return await _service.GetByIdAsync(cancellationToken, id);
        }
        /// <summary>
        /// Creates user and saves it to database
        /// </summary>
        /// 
        [HttpPost]
        public async Task Create(CancellationToken cancellationToken, AddressRequestModel request)
        {
            await _service.CreateAsnyc(cancellationToken, request);
        }
        /// <summary>
        /// Updates specified address' information
        /// </summary>
        [HttpPut("{id}")]
        public async Task Update(CancellationToken cancellationToken, AddressRequestModel request, int id)
        {
            await _service.UpdateAsnyc(cancellationToken, request, id);
        }
        /// <summary>
        /// Deletes specified address from database
        /// </summary>
        [HttpDelete("{id}")]
        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            await _service.DeleteAsync(cancellationToken, id);
        }
    }
}
