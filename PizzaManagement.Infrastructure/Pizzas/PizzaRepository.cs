using Microsoft.EntityFrameworkCore;
using PizzaManagement.Domain.Pizzas;
using PizzaManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Infrastructure.Pizzas
{
    public class PizzaRepository : IPizzaRepository
    {
        readonly PizzaManagerDbContext _context;
        public PizzaRepository(PizzaManagerDbContext context) 
        {
            _context = context;
        }
        public async Task CreateAsnyc(CancellationToken cancellationToken, Pizza pizza)
        {
            await _context.AddAsync(pizza);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var pizzaToBeDeleted = await GetByIdAsync(cancellationToken, id);
            if (pizzaToBeDeleted == null)
            {
                return false;
            }
            //_context.Pizzas.Remove(pizzaToBeDeleted);
            pizzaToBeDeleted.IsDeleted=true;
            _context.Pizzas.Update(pizzaToBeDeleted);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<Pizza>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Pizzas.Select(p=>p).Where(p=>p.IsDeleted==false).ToListAsync(cancellationToken);
        }

        public async Task<Pizza> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _context.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
            return result;
        }

        public async Task UpdateAsnyc(CancellationToken cancellationToken, Pizza pizza)
        {
            _context.Pizzas.Update(pizza);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            return await _context.Pizzas.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> IsDeleted(CancellationToken cancellationToken, int id)
        {
            var result = await _context.Pizzas.FirstOrDefaultAsync(u => u.Id == id);
            return result.IsDeleted;
        }
        public async Task<int> CalculatePizzaRank(CancellationToken cancellationToken, int id)
        {
            var HistoryList = await _context.RankHistories.Where(rh => rh.PizzaId == id).ToListAsync(cancellationToken);
            int averageRank = 0;
            foreach (var rank in HistoryList)
            {
                averageRank += rank.rank;
            }
            if (averageRank > 0) { averageRank /= HistoryList.Count; }
            else { averageRank = -1; }
            return averageRank;
        }
    }
}
