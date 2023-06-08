using PizzaManagement.Application.Pizzas.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Infrastructure.Models.ExampleModels
{
    public class PizzaCreateExample : IExamplesProvider<PizzaRequestModel>
    {
        public PizzaRequestModel GetExamples()
        {
            return new PizzaRequestModel
            {
                Name = "Pepperoni",
                Price = 23,
                ImageId = null,
                Description = "Pepperoni pizza is an American pizza variety which includes one of the country's most beloved toppings.",
                CaloryCount = 1800
            };
        }
    }
}
