using PizzaManagement.Domain.Images;
using PizzaManagement.Domain.Orders;
using PizzaManagement.Domain.RankHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Domain.Pizzas
{
    public class Pizza:Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int? ImageId { get; set; }
        public string Description { get; set; }
        public int CaloryCount { get; set; }

        public virtual Image Image { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<RankHistory> RankHistories { get; set; }
    }
}
