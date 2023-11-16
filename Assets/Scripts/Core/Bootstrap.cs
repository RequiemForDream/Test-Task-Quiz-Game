using Counters;
using Questions;
using UI;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private QuestionConfiguration _questionConfiguration;
        [SerializeField] private Transform _questionContainer;
        [SerializeField] private GameOverScreen _gameOverScreen;

        private void Awake()
        {
            var scoreCounter = BindCorrectAnswerCounter();
            _gameOverScreen.Initialize(scoreCounter);
            var questionGenerator = BindQuestionGenerator(scoreCounter);
        }

        private QuestionGenerator BindQuestionGenerator(CorrectAnswersCounter correctAnswersCounter)
        {
            return new QuestionGenerator(_questionContainer, _questionConfiguration, correctAnswersCounter);
        }

        private CorrectAnswersCounter BindCorrectAnswerCounter()
        {
            return new CorrectAnswersCounter();
        }
    }
}

