using PizzaManagement.Application.Images.Requests;
using PizzaManagement.Application.Images.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Images
{
    public interface IImageService
    {
        public Task<List<ImageResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        public Task<ImageResponseModel> GetByIdAsync(CancellationToken cancellationToken, int id);
        public Task DeleteAsync(CancellationToken cancellationToken, int id);
        public Task CreateAsnyc(CancellationToken cancellationToken, ImageRequestModel user);
        public Task UpdateAsnyc(CancellationToken cancellationToken, ImageRequestModel user);
    }
}
