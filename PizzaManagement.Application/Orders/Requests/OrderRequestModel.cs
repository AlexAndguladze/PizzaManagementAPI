using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Orders.Requests
{
    public class OrderRequestModel
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        // public List<Pizza> Pizzas { get; set; }
        public int PizzaId { get; set; }
    }
}
