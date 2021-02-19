using Dapper;
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
    public class GameDapperRepository : IGameRepository
    {
        private const string CONNECTION_STRING = "Data Source=SAMARITAN;Database=Test;Trusted_Connection=True;";
        public Game Create(Game model)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = $"INSERT INTO Games(GameName) OUTPUT INSERTED.id VALUES(\'{model.GameName}\')";
                var insertedId = connection.ExecuteScalar(queryString);
                var insertedIdInt = Convert.ToInt32(insertedId);
                model.Id = insertedIdInt;
                return model;
            }
        }

        public IEnumerable<Game> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                return connection.Query<Game>("SELECT * FROM Games");
            }
        }
    }
}