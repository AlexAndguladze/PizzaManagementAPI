using Microsoft.AspNetCore.Mvc;
using PizzaManagement.Application.Addresses;
using PizzaManagement.Application.Orders;
using PizzaManagement.Application.Orders.Requests;
using PizzaManagement.Application.Orders.Responses;

namespace PizzaManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IAddressService _addressService;

        public OrderController(IOrderService service, IAddressService addressService)
        {
            _service = service;
            _addressService = addressService;
        }
        [HttpGet]
        public async Task<List<OrderResponseModel>> GetAll(CancellationToken cancellation)
        {
            return await _service.GetAllAsync(cancellation);
        }
        [HttpGet("{id}")]
        public async Task<OrderResponseModel> GetById(CancellationToken cancellationToken, int id)
        {
            return await _service.GetByIdAsync(cancellationToken, id);
        }
        [HttpPost]
        public async Task Create(CancellationToken cancellationToken, OrderRequestModel request)
        {
            
            await _service.CreateAsnyc(cancellationToken, request);
        }
    }
}
