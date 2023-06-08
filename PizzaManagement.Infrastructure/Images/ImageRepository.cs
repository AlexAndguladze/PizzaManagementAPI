using PizzaManagement.Domain.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Infrastructure.Images
{
    public class ImageRepository : IImageRepository
    {
        public Task CreateAsnyc(CancellationToken cancellationToken, Image user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Image>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsDeleted(CancellationToken cancellationToken, int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsnyc(CancellationToken cancellationToken, Image user)
        {
            throw new NotImplementedException();
        }
    }
}
