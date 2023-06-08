using PizzaManagement.Domain.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Infrastructure.Images
{
    public interface IImageRepository
    {
        public Task<List<Image>> GetAllAsync(CancellationToken cancellationToken);
        public Task<Image> GetByIdAsync(CancellationToken cancellationToken, int id);
        public Task DeleteAsync(CancellationToken cancellationToken, int id);
        public Task CreateAsnyc(CancellationToken cancellationToken, Image user);
        public Task UpdateAsnyc(CancellationToken cancellationToken, Image user);
        public Task<bool> IsDeleted(CancellationToken cancellationToken, int id);
    }
}
