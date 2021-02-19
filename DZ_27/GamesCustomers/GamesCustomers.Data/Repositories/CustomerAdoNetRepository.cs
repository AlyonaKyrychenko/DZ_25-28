using GamesCustomers.Data.Models;
using GamesCustomers.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCustomers.Data.Repositories
{
    public class CustomerAdoNetRepository : ICustomerRepository
    {
        private const string CONNECTION_STRING = "Data Source=SAMARITAN;Database=Test;Trusted_Connection=True;";

        public Customer Create(Customer model)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = "INSERT INTO Customers(FirstName,LastName,PurchaseId) OUTPUT INSERTED.id VALUES(@FirstName,@LastName,1)";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("@LastName", model.LastName);
                connection.Open();
                model.Id = Convert.ToInt32(command.ExecuteScalar());
                return model;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            var result = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = "SELECT * FROM Customers";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Customer
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2)
                    });
                }
                reader.Close();
                return result;
            }
        }
    }
}
