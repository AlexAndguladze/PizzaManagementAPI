using PizzaManagement.Application.Users.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Infrastructure.Models.ExampleModels
{
    public class UserCreateExample : IExamplesProvider<UserRequestModel>
    {
        public UserRequestModel GetExamples()
        {
            return new UserRequestModel
            {
                FirstName = "ალექსანდრე",
                LastName = "ანდღულაძე",
                Email = "example@gmail.com",
                PhoneNumber = "555 33 22 11"
            };
        }
    }
}
