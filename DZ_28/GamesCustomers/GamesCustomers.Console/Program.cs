using GamesCustomers.Controllers;
using GamesCustomers.Data.Repositories;
using GamesCustomers.Domain.Services;
using GamesCustomers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCustomers.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TastingGames();
            TastingCustomers();
        }

        public static void TastingGames()
        {
            var repository = new GameDapperRepository();
            var subscriptionRepository = new SubscriptionRepository();
            var service = new CustomerService(repository, subscriptionRepository);
            var controller = new GamesController(service);

            var gamePostModel = new GamePostModel { GameName = "SomeGame", GameKey = 10 };

            controller.Create(gamePostModel);

            var games = controller.GetAll();
        }

        public static void TastingCustomers()
        {
            var repository = new CustomerAdoNetRepository();
            var subscriptionRepository = new SubscriptionRepository();
            var service = new CustomerService(repository, subscriptionRepository);
            var controller = new CustomersController(service);

            var customerPostModel = new CustomerPostModel { FirstName = "SomeFirstName", LastName = "SomeLastName" };

            controller.Create(customerPostModel);

            var customers = controller.GetAll();
        }
    }
}
