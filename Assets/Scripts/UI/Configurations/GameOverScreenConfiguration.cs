using UnityEngine;

namespace UI.Configurations
{
    [CreateAssetMenu(fileName = "Game Over Screen Configuration", menuName = "UI Configurations / New Game Over Screen Configuration")]
    public class GameOverScreenConfiguration : ScriptableObject
    {
        [SerializeField] private GameOverScreen _gameOverScreenPrefab;

        public GameOverScreen GameOverScreenPrefab => _gameOverScreenPrefab;
    }
}

