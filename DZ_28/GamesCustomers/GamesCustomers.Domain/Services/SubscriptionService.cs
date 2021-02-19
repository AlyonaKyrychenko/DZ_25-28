using GamesCustomers.Data.Models;
using GamesCustomers.Data.Repositories.Interfaces;
using GamesCustomers.Domain.Models;
using GamesCustomers.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCustomers.Domain.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionsRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionsRepository)
        {
            _subscriptionsRepository = subscriptionsRepository;
        }
        public IEnumerable<SubscriptionModel> GetAll()
        {
            var subscriptions = _subscriptionsRepository.GetAll();
            var result = new List<SubscriptionModel>();

            foreach (var subscription in subscriptions)
            {
                result.Add(new SubscriptionModel
                {
                    Id = subscription.Id,
                    Code = subscription.Code,
                });
            }

            return result;
        }

        public SubscriptionModel GetSubscription(int subscription)
        {
            var subscript = _subscriptionsRepository.GetSubscription(subscription);
            var result = new SubscriptionModel { Id = subscript.Id, Subscription = subscript.Subscription };
            return result;
        }
    }
}
