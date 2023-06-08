using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.CustomExceptions
{
    public class ItemIsDeletedException:Exception
    {
        public string code = "ItemIsDeletedException";

        public ItemIsDeletedException(string message):base(message)
        {

        }
    }
}
