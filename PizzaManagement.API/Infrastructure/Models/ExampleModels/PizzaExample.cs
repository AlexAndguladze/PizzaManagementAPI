using PizzaManagement.Application.Pizzas.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Infrastructure.Models.ExampleModels
{
    public class PizzaExample : IExamplesProvider<PizzaByIdResponseModel>
    {
        public PizzaByIdResponseModel GetExamples()
        {
            return new PizzaByIdResponseModel
            {
                Id =1,
                Name ="Pepperoni",
                Price =23,
                ImageId=1,
                Description = "Pepperoni pizza is an American pizza variety which includes one of the country's most beloved toppings",
                CaloryCount = 2000,
                Rank =9
            };
        }
    }
}
