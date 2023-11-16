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
        public bool IsActiveByAwake = false;

        private CorrectAnswersCounter _correctAnswerCounter;

        public override void Awake()
        {
            Extensions.Subscribe(_startNewGameButton, StartNewGame);
            //gameObject.SetActive(IsActiveByAwake);
        }

        public void Initialize(CorrectAnswersCounter correctAnswersCounter)
        {
            _correctAnswerCounter = correctAnswersCounter;
            _correctAnswerCounter.OnCorrectAnswerClicked += DisplayScoreCount;
        }

        private void DisplayScoreCount(int value)
        {
            _scoreCount.text = "Правильных ответов: /n" + value.ToString();
        }

        private void StartNewGame()
        {
            SceneLoader sceneLoader = new SceneLoader(DataClass.MainMenuSceneIndex);
            sceneLoader.LoadSceneByBuildIndex();
        }
    }
}

