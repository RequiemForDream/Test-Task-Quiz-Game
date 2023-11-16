using Answers;
using Answers.Interfaces;
using Core.Interfaces;
using Counters;
using Factories;
using Factories.Interfaces;
using Questions;
using Questions.Interfaces;
using UI;
using UI.Configurations;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private QuestionConfiguration _questionConfiguration;
        [SerializeField] private AnswerConfiguration _answerConfiguration;
        [SerializeField] private GameOverScreenConfiguration _gameOverScreenConfiguration;
        [SerializeField] private QuestionResultScreenConfiguration _questionResultConfiguration;
        [SerializeField] private CanvasConfiguration _canvasConfiguration;

        private void Awake()
        {
            var scoreCounter = BindCorrectAnswerCounter();
            var canvas = BindCanvas();
            var gameOverScreen = BindGameOverScreen();
            gameOverScreen.Initialize(scoreCounter, canvas.transform);
            var resultScreenFactory = BindQuestionResultScreenFactory();
            var answerFactory = BindAnswerFactory();
            var questionFactory = BindQuestionFactory(scoreCounter, resultScreenFactory, answerFactory);
            var questionGenerator = BindQuestionGenerator(questionFactory, canvas.transform);
            var level = new Level( (IGameEnd) questionFactory, questionGenerator, gameOverScreen);
            level.Start();
        }

        private Canvas BindCanvas()
        {
            var canvasFactory = new CanvasFactory(_canvasConfiguration);
            return canvasFactory.Create();
        }

        private GameOverScreen BindGameOverScreen()
        {
            var gameOverScreenFactory = new GameOverScreenFactory(_gameOverScreenConfiguration);
            return gameOverScreenFactory.Create();
        }

        private IFactory<IQuestionResultScreen> BindQuestionResultScreenFactory()
        {
            return new QuestionResultScreenFactory(_questionResultConfiguration);
        }

        private IFactory<IAnswer> BindAnswerFactory()
        {
            return new AnswerFactory(_answerConfiguration);
        }

        private IFactory<IQuestion> BindQuestionFactory(CorrectAnswersCounter correctAnswersCounter, 
            IFactory<IQuestionResultScreen> questionResultScreenFactory, IFactory<IAnswer> answerFactory)
        {
            return new QuestionFactory(_questionConfiguration, correctAnswersCounter, questionResultScreenFactory, answerFactory);
        }

        private QuestionGenerator BindQuestionGenerator(IFactory<IQuestion> questionFactory, Transform container)
        {
            return new QuestionGenerator(container, questionFactory);
        }

        private CorrectAnswersCounter BindCorrectAnswerCounter()
        {
            return new CorrectAnswersCounter();
        }
    }
}

