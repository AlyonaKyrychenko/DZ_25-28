using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCustomers.Data.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
