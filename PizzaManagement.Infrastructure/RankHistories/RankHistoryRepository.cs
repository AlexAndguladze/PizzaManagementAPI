using Microsoft.EntityFrameworkCore;
using PizzaManagement.Domain.RankHistories;
using PizzaManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Infrastructure.RankHistories
{
    public class RankHistoryRepository : IRankHistoryRepository
    {
        private readonly PizzaManagerDbContext _context;

        public RankHistoryRepository(PizzaManagerDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsnyc(CancellationToken cancellationToken, RankHistory rankHistory)
        {
            await _context.AddAsync(rankHistory);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<RankHistory>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.RankHistories.Select(o => o).Where(o => o.IsDeleted == false).ToListAsync(cancellationToken);
        }

        public async Task<RankHistory> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _context.RankHistories.FirstOrDefaultAsync(rh => rh.Id == id);

            return result;
        }

        public async Task<bool> IsDeleted(CancellationToken cancellationToken, int id)
        {
            throw new NotImplementedException();
        }
    }
}
