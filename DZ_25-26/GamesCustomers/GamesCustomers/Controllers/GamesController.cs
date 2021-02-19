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
    public class GamesController
    {
        private readonly GameService _gamesService;

        public GamesController(GameService gamesService)
        {
            _gamesService = gamesService;
        }

        public IEnumerable<GameViewModel> GetAll()
        {
            var games = _gamesService.GetAll();

            var result = new List<GameViewModel>();

            foreach (var game in games)
            {
                result.Add(new GameViewModel
                {
                    Id = game.Id,
                    GameName = game.GameName,
                });
            }

            return result;
        }

        public GameViewModel Create(GamePostModel model)
        {
            if (model.GameName.Contains(" "))
            {
                return new GameViewModel { GameName = "Validation error" };
            }
            var GameModel = new GameModel
            {
                GameName = model.GameName,
            };

            var createResult = _gamesService.Create(GameModel);

            var result = new GameViewModel
            {
                Id = createResult.Id,
                GameName = createResult.GameName,
            };

            return result;
        }
    }
}
