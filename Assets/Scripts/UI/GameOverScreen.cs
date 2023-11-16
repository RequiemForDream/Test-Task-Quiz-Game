using Counters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace UI
{
    public class GameOverScreen : Screen
    {
        [SerializeField] private Button _startNewGameButton;
        [SerializeField] private TMP_Text _scoreCount;
        [SerializeField] private bool IsActiveByAwake = false;

        private CorrectAnswersCounter _correctAnswerCounter;

        public void Initialize(CorrectAnswersCounter correctAnswersCounter, Transform parent)
        {
            gameObject.transform.SetParent(parent, false);
            _correctAnswerCounter = correctAnswersCounter;
            Extensions.Subscribe(_startNewGameButton, StartNewGame);
            gameObject.SetActive(IsActiveByAwake);
            _correctAnswerCounter.OnCorrectAnswerClicked += DisplayScoreCount;
        }

        private void DisplayScoreCount(int value)
        {
            _scoreCount.text = "Правильных ответов: " + value.ToString();
        }

        private void StartNewGame()
        {
            SceneLoader sceneLoader = new SceneLoader(DataClass.MainMenuSceneIndex);
            sceneLoader.LoadSceneByBuildIndex();
        }
    }
}

