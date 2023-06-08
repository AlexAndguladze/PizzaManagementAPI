using Mapster;
using PizzaManagement.Application.CustomExceptions;
using PizzaManagement.Application.Pizzas.Requests;
using PizzaManagement.Application.Pizzas.Responses;
using PizzaManagement.Domain.Pizzas;
using PizzaManagement.Infrastructure.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Pizzas
{
    public class PizzaService : IPizzaService
    {
        readonly IPizzaRepository _repo;
        public PizzaService(IPizzaRepository repo)
        {
            _repo = repo;
        }
        public async Task CreateAsnyc(CancellationToken cancellationToken, PizzaRequestModel pizza)
        {
            var pizzaToInsert = pizza.Adapt<Pizza>();
            await _repo.CreateAsnyc(cancellationToken, pizzaToInsert);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var isDeleted = await _repo.IsDeleted(cancellationToken, id);
            if (isDeleted)
            {
                throw new ItemIsDeletedException($"{nameof(Pizza)} is Already deleted from database");
            }
            var result = await _repo.DeleteAsync(cancellationToken, id);
            if (result == false)
            {
                throw new NotFoundException($"{nameof(Pizza)} could not be found in database");
            }
        }

        public async Task<List<PizzaResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var listOfPizzas = await _repo.GetAllAsync(cancellationToken);

            return listOfPizzas.Adapt<List<PizzaResponseModel>>();
        }

        public async Task<PizzaByIdResponseModel> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            var pizza = await _repo.GetByIdAsync(cancellationToken, id);
            if(pizza == null)
            {
                throw new NotFoundException($"{nameof(Pizza)} with this Id could not be found in database");
            }
            var isDeleted = await _repo.IsDeleted(cancellationToken, id);
            if (isDeleted)
            {
                throw new ItemIsDeletedException($"{nameof(Pizza)} is deleted from database");
            }
            int avergeRank =await _repo.CalculatePizzaRank(cancellationToken, id);

            var result =pizza.Adapt<PizzaByIdResponseModel>();
            result.Rank = avergeRank;
            return result;
        }

        public async Task UpdateAsnyc(CancellationToken cancellationToken, PizzaRequestModel pizza, int id)
        {
            var exists = await _repo.Exists(cancellationToken, id);
            if(exists == false)
            {
                throw new NotFoundException($"{nameof(Pizza)} could not be found in database");
            }
            var isDeleted = await _repo.IsDeleted(cancellationToken, id);
            if (isDeleted)
            {
                throw new ItemIsDeletedException($"{nameof(Pizza)} is deleted from database");
            }
            var pizzaToUpdate = pizza.Adapt<Pizza>();
            pizzaToUpdate.Id = id;
            await _repo.UpdateAsnyc(cancellationToken,pizzaToUpdate);
        }
    }
}
