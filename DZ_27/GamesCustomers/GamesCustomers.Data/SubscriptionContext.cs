using GamesCustomers.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCustomers.Data
{
    public class SubscriptionContext : DbContext
    {
        public SubscriptionContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
