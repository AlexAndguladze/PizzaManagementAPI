using PizzaManagement.Domain.Addresses;
using PizzaManagement.Domain.Pizzas;
using PizzaManagement.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Domain.Orders
{
    public class Order:Entity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
       // public List<Pizza> Pizzas { get; set; }
        public int PizzaId { get; set; }
        
        public virtual Pizza Pizza { get; set; }
        public virtual User User { get; set; }
        public virtual Address Address { get; set; }
    }
}
