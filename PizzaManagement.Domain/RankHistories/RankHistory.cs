using PizzaManagement.Domain.Pizzas;
using PizzaManagement.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Domain.RankHistories
{
    public class RankHistory:Entity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public int rank { get; set; }

        public virtual User User { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
