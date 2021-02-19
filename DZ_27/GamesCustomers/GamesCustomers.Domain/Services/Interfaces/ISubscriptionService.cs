using GamesCustomers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GamesCustomers.Domain.Services.Interfaces
{
    public interface ISubscriptionService
    {
        IEnumerable<SubscriptionModel> GetAll();
        SubscriptionModel GetSubscription(int subscription);
    }
}
