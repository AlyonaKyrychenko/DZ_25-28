using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCustomers.Domain.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public int GameKey { get; set; }
    }
}
