using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.CustomExceptions
{
    public class NotFoundException:Exception
    {
        public string code = "NotFoundException";
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
