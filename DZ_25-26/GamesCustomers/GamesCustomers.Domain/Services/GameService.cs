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
    public class GameService : IGameService
    {
        private readonly IGameRepository _gamesRepository;

        public GameService(IGameRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public GameModel Create(GameModel model)
        {
            if (!Validation(model))
            {
                throw new Exception("Validation error in BL.");
            }
            var game = new Game
            {
                GameName = model.GameName,
                GameKey = model.GameKey
            };

            _gamesRepository.Create(game);

            model.Id = game.Id;

            return model;
        }

        public IEnumerable<GameModel> GetAll()
        {
            var games = _gamesRepository.GetAll();
            var result = new List<GameModel>();

            foreach (var game in games)
            {
                result.Add(new GameModel
                {
                    Id = game.Id,
                    GameName = game.GameName,
                });
            }

            return result;
        }

        private bool Validation(GameModel model)
        {
            var result = false;
            var random = new Random();
            if (random.Next(100) > 10)
                result = true;
            return result;
        }
    }
}
