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
        public SubscriptionContext() : base("Default")
        {

        }

        public SubscriptionContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Game> Game { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Subscription>().HasKey(x => x.Id);
            modelBuilder.Entity<Subscription>().Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Game>().HasMany(x => x.Games).WithRequired(x => x.Subscription).HasForeignKey(x => x.GameId);
            modelBuilder.Entity<Game>().HasKey(x => x.Id);
            modelBuilder.Entity<Subscription>().HasRequired(x => x.Game).WithMany(x => x.Subscriptions);
        }
    }
}
