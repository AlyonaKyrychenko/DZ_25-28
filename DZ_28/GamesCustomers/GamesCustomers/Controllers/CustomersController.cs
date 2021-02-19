using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesCustomers.Domain;
using GamesCustomers.Domain.Models;
using GamesCustomers.Domain.Services;
using GamesCustomers.Models;

namespace GamesCustomers.Controllers
{
    public class CustomersController
    {
        private readonly CustomerService _customersService;

        public CustomerController(CustomerService customersService)
        {
            _customersService = customersService;
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            var customers = _customersService.GetAll();

            var result = new List<CustomerViewModel>();

            foreach (var customer in customers)
            {
                result.Add(new CustomerViewModel
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PurchaseId = "Unknown purchase"
                });
            }

            return result;
        }

        public CustomerViewModel Create(CustomerPostModel model)
        {
            if (model.FirstName.Contains(" "))
            {
                return new CustomerViewModel { FirstName = "Validation error", LastName = "Validation error" };
            }
            var customerrModel = new CustomerModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Subscription = model.Subscription
            };

            var createResult = _customersService.Create(customerrModel);

            var result = new CustomerViewModel
            {
                Id = createResult.Id,
                FirstName = createResult.FirstName,
                LastName = createResult.LastName
            };

            return result;
        }
    }
}
