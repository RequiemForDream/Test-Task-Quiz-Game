using Factories.Interfaces;
using UI;
using Object = UnityEngine.Object;

namespace Factories
{
    public class GameOverScreenFactory : IFactory<GameOverScreen>
    {
        private readonly GameOverScreenConfig _gameOverScreenConfig;

        public GameOverScreenFactory(GameOverScreenConfig gameOverScreenConfig)
        {
            _gameOverScreenConfig = gameOverScreenConfig;
        }

        public GameOverScreen Create()
        {
            var gameOverScreen = Object.Instantiate(_gameOverScreenConfig.GameOverScreenPrefab);

            return gameOverScreen;
        }
    }
}
