using PizzaManagement.Application.RankHistories.Requests;
using PizzaManagement.Application.RankHistories.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.RankHistories
{
    public interface IRankHistoryService
    {
        public Task<List<RankHistoryResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        public Task<RankHistoryResponseModel> GetByIdAsync(CancellationToken cancellationToken, int id);//pizza id?
        public Task CreateAsnyc(CancellationToken cancellationToken, RankHistoryRequestModel user);
    }
}
