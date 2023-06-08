using PizzaManagement.Application.Pizzas.Requests;
using PizzaManagement.Application.Pizzas.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Pizzas
{
    public interface IPizzaService
    {
        public Task<List<PizzaResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        public Task<PizzaByIdResponseModel> GetByIdAsync(CancellationToken cancellationToken, int id);
        public Task DeleteAsync(CancellationToken cancellationToken, int id);
        public Task CreateAsnyc(CancellationToken cancellationToken, PizzaRequestModel pizza);
        public Task UpdateAsnyc(CancellationToken cancellationToken, PizzaRequestModel pizza, int id);
        //public Task<bool>Exists(CancellationToken cancellationToken, int id);
    }
}
