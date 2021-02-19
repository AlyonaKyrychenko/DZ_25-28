using GamesCustomers.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GamesCustomers.Data.Repositories.Interfaces
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAll();
        Game Create(Game model);
    }
}
