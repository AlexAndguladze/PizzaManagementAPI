using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Pizzas.Requests
{
    public class PizzaRequestModel
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int? ImageId { get; set; }
        public string Description { get; set; }
        public int CaloryCount { get; set; }
    }
}
