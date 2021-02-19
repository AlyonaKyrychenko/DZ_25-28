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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customersRepository;

        public CustomerService(ICustomerRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public CustomerModel Create(CustomerModel model)
        {
            if (!Validation(model))
            {
                throw new Exception("Validation error in BL.");
            }

            var customer = new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Subscription = model.Subscription
            };

            _customersRepository.Create(customer);

            model.Id = customer.Id;

            return model;
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            var customers = _customersRepository.GetAll();
            var result = new List<CustomerModel>();

            foreach (var customer in customers)
            {
                result.Add(new CustomerModel
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                });
            }

            return result;
        }

        private bool Validation(CustomerModel model)
        {
            var result = false;
            var random = new Random();
            if (random.Next(100) > 10)
                result = true;
            return result;
        }
    }
}
