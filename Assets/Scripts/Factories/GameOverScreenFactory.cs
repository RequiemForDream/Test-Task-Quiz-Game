using Factories.Interfaces;
using UI;
using UI.Configurations;
using Object = UnityEngine.Object;

namespace Factories
{
    public class GameOverScreenFactory : IFactory<GameOverScreen>
    {
        private readonly GameOverScreenConfiguration _gameOverScreenConfig;

        public GameOverScreenFactory(GameOverScreenConfiguration gameOverScreenConfig)
        {
            _gameOverScreenConfig = gameOverScreenConfig;
        }

        public GameOverScreen Create()
        {
            var gameOverScreen = Object.Instantiate(_gameOverScreenConfig.GameOverScreenPrefab);

            return gameOverScreen;
        }

        public void Reclaim(Object obj)
        {
            Object.Destroy(obj);
        }
    }
}
