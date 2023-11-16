using Answers.Interfaces;
using Core.Interfaces;
using Counters;
using Factories.Interfaces;
using Questions;
using Questions.Interfaces;
using System;
using UI;
using Utilities;
using Object = UnityEngine.Object;

namespace Factories
{
    public class QuestionFactory : IFactory<IQuestion>, IGameEnd
    {
        public event Action OnGameEnded;

        private readonly QuestionConfiguration _questionConfiguration;
        private readonly CorrectAnswersCounter _correctAnswerCounter;
        private readonly IFactory<IQuestionResultScreen> _questionResultScreenFactory;
        private readonly IFactory<IAnswer> _answerFactory;

        private QuestionEntity[] _questionsEntities;
        private int _number = 0;

        public QuestionFactory(QuestionConfiguration questionConfiguration, CorrectAnswersCounter correctAnswersCounter,
            IFactory<IQuestionResultScreen> questionResultScreenFactory, IFactory<IAnswer> answerFactory)
        {
            _questionConfiguration = questionConfiguration;
            _correctAnswerCounter = correctAnswersCounter;
            _questionResultScreenFactory = questionResultScreenFactory;
            _answerFactory = answerFactory;

            GetQuestionArray();
        }

        public IQuestion Create()
        {
            if (_number == _questionsEntities.Length)
            {
                OnGameEnded?.Invoke();    
                return null;
            }

            var questionView = Object.Instantiate(_questionConfiguration.QuestionView);
            var question = new Question(questionView, _questionConfiguration.QuestionModel, _correctAnswerCounter,
                _questionsEntities[_number], _questionResultScreenFactory, _answerFactory);

            _number++;

            return question;
        }

        private void GetQuestionArray()
        {
            var jsonLoader = new JsonLoader();
            _questionsEntities = jsonLoader.LoadFromJson().questions;
        }

        public void Reclaim(Object obj)
        {
            Object.Destroy(obj);
        }
    }
}
