using PizzaManagement.Domain.RankHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Infrastructure.RankHistories
{
    public interface IRankHistoryRepository
    {
        public Task<List<RankHistory>> GetAllAsync(CancellationToken cancellationToken);
        public Task<RankHistory> GetByIdAsync(CancellationToken cancellationToken, int id);
        public Task CreateAsnyc(CancellationToken cancellationToken, RankHistory rankHistory);
        public Task<bool> IsDeleted(CancellationToken cancellationToken, int id);
    }
}
