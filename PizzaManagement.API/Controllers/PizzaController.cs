using Microsoft.AspNetCore.Mvc;
using PizzaManagement.API.Infrastructure.Models.ExampleModels;
using PizzaManagement.Application.Pizzas;
using PizzaManagement.Application.Pizzas.Requests;
using PizzaManagement.Application.Pizzas.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _service;

        public PizzaController(IPizzaService service)
        {
            _service = service;
        }
        /// <summary>
        /// Returns all pizzas from database
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        /// 
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PizzaResponseModel>), StatusCodes.Status200OK)]
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!  ეს swagger-ს Fail-ს უკეთებს 
        //[SwaggerResponseExample(StatusCodes.Status200OK, typeof(IEnumerable<PizzaResponseModel>))] 
        [HttpGet]
        public async Task<List<PizzaResponseModel>> GetAll(CancellationToken cancellation)
        {
            return await _service.GetAllAsync(cancellation);
        }
        /// <summary>
        /// Gets specified pizza from database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        ///
        [ProducesResponseType(typeof(PizzaByIdResponseModel), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<PizzaByIdResponseModel> GetById(CancellationToken cancellationToken, int id)
        {
            return await _service.GetByIdAsync(cancellationToken, id);
        }
        /// <summary>
        /// Creates pizza and saves it to database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        [SwaggerRequestExample(typeof(PizzaRequestModel), typeof(PizzaCreateExample))]
        [HttpPost]
        public async Task Create(CancellationToken cancellationToken, PizzaRequestModel request)
        {
            await _service.CreateAsnyc(cancellationToken, request);
        }
        /// <summary>
        /// Updates specified pizza's information
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task Update(CancellationToken cancellationToken, PizzaRequestModel request, int id)
        {
            await _service.UpdateAsnyc(cancellationToken, request, id);
        }
        /// <summary>
        /// Deletes specified pizza from database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            await _service.DeleteAsync(cancellationToken, id);
        }
    }
}
