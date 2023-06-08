using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.RankHistories.Requests
{
    public class RankHistoryRequestModel
    {
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public int rank { get; set; }
    }
}
