using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Pizzas.Responses
{
    public class PizzaResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }//decimal mqonda magram migraciisas dazusteba chirdeboda zomis da agar mivyevi
        public int ImageId { get; set; }
        public string Description { get; set; }
        public int CaloryCount { get; set; }
    }
}
