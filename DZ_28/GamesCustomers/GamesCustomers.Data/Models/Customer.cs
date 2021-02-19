﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCustomers.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PurchaseId { get; set; }
        public int Subscription { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
