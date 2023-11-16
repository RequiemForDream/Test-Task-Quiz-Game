using UnityEngine;

namespace UI
{
    [CreateAssetMenu]
    public class GameOverScreenConfig : ScriptableObject
    {
        [SerializeField] private GameOverScreen _gameOverScreenPrefab;

        public GameOverScreen GameOverScreenPrefab => _gameOverScreenPrefab;
    }
}

