using Core.Interfaces;
using StateMachine;
using UI;

namespace Core
{
    public class Level
    {
        private readonly IGameEnd _gameEnder;
        private readonly QuestionGenerator _questionGenerator;
        private readonly GameOverScreen _gameOverScreen;

        private GameStateMachine _gameStateMachine;

        public Level(IGameEnd gameEnder, QuestionGenerator questionGenerator, GameOverScreen gameOverScreen)
        {
            _gameEnder = gameEnder;
            _questionGenerator = questionGenerator;
            _gameOverScreen = gameOverScreen;
        }

        public void Start()
        {
            _gameEnder.OnGameEnded += SetGameOverState;
            _gameStateMachine = new GameStateMachine();
            InitializeStates();
        }

        private void InitializeStates()
        {
            GameOverState gameOverState = new GameOverState(_gameOverScreen);
            GameplayState gameplayState = new GameplayState(_questionGenerator);

            _gameStateMachine.AddState<GameOverState>(gameOverState);
            _gameStateMachine.AddState<GameplayState>(gameplayState);

            _gameStateMachine.ChangeState<GameplayState>();
        }

        private void SetGameOverState()
        {
            _gameStateMachine.ChangeState<GameOverState>();
        }
    }
}

