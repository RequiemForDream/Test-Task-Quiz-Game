using UI;
using UnityEngine;
using Utilities;

namespace StateMachine
{
    public class GameOverState : State
    {
        private readonly GameOverScreen _gameOverScreen;

        public GameOverState(GameOverScreen gameOverScreen)
        {
            _gameOverScreen = gameOverScreen;
        }

        public override void Enter()
        {
            Extensions.Activate(_gameOverScreen.gameObject);
            _gameOverScreen.transform.SetAsLastSibling();
        }
    }
}
