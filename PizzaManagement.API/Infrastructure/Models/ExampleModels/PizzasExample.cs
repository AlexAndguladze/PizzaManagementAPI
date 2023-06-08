using PizzaManagement.Application.Pizzas.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Infrastructure.Models.ExampleModels
{
    public class PizzasExample : IMultipleExamplesProvider<PizzaResponseModel>
    {
        public IEnumerable<SwaggerExample<PizzaResponseModel>> GetExamples()
        {
            yield return SwaggerExample.Create("Example 1", new PizzaResponseModel
            {
                Id = 1,
                Name = "Pepperoni",
                Price = 23,
                ImageId = 1,
                Description = "Pepperoni pizza is an American pizza variety which includes one of the country's most beloved toppings",
                CaloryCount = 2000
            });
            yield return SwaggerExample.Create("Example 1", new PizzaResponseModel
            {
                Id = 2,
                Name = "Margherita",
                Price = 26,
                ImageId = 2,
                Description = "sophisticated version of your basic cheese pizza and also a wonderful Caprese salad, but with a crust",
                CaloryCount = 2300
            });
        }
    }
}
