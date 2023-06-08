using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.CustomExceptions
{
    public class UserNotFoundException:Exception
    {
        public string code = "UserNotFound";
        private const string UserNotFoundMessage = "User with this Id could not be found in database";
        public UserNotFoundException(string msg) : base(msg)
        {

        }
        public UserNotFoundException() : base(UserNotFoundMessage)
        {

        }
    }
}
