using PizzaManagement.Domain.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Infrastructure.Pizzas
{
    public interface IPizzaRepository
    {
        public Task<List<Pizza>> GetAllAsync(CancellationToken cancellationToken);
        public Task<Pizza> GetByIdAsync(CancellationToken cancellationToken, int id);
        public Task<bool> DeleteAsync(CancellationToken cancellationToken, int id);
        public Task CreateAsnyc(CancellationToken cancellationToken, Pizza pizza);
        public Task UpdateAsnyc(CancellationToken cancellationToken, Pizza pizza);
        public Task<bool> Exists(CancellationToken cancellationToken, int id);
        public Task<bool> IsDeleted(CancellationToken cancellationToken, int id);
        public Task<int> CalculatePizzaRank(CancellationToken cancellationToken, int id);
    }
}
