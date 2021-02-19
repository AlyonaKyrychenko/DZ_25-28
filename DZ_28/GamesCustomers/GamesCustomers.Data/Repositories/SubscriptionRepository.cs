using GamesCustomers.Data.Models;
using GamesCustomers.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCustomers.Data.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        public IEnumerable<Subscription> GetAll()
        {
            using (var ctx = new SubscriptionContext("Default"))
            {
                return ctx.Subscriptions.ToList();
            };
        }

        public Subscription GetSubscription(int subscription)
        {
            using (var ctx = new SubscriptionContext("Default"))
            {
                return ctx.Subscriptions.FirstOrDefault(w => w.Subscription == subscription);
            };
        }
    }
}
