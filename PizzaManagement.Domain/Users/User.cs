using PizzaManagement.Domain.Addresses;
using PizzaManagement.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Domain.Users
{
    public class User:Entity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Address> Adresses { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
    }
}
