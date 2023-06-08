using PizzaManagement.Domain.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Domain.Images
{
    public class Image:Entity
    {
        public int Id { get; set; }
        public Pizza Pizza { get; set; }
        public int PizzaId { get; set; }
        public string OriginalName { get; set; }
        public string Path { get; set; }
    }
}
