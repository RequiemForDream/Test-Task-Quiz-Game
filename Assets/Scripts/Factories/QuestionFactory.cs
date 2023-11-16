using Counters;
using Factories.Interfaces;
using Questions;
using Questions.Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Factories
{
    public class QuestionFactory : IFactory<IQuestion>
    {
        private readonly QuestionConfiguration _questionConfiguration;
        private readonly CorrectAnswersCounter _correctAnswerCounter;
        private QuestionEntity[] _questionsEntities;
        private int _number = 0;

        public QuestionFactory(QuestionConfiguration questionConfiguration, CorrectAnswersCounter correctAnswersCounter)
        {
            _questionConfiguration = questionConfiguration;
            _correctAnswerCounter = correctAnswersCounter;
            GetQuestionArray();
        }

        public IQuestion Create()
        {
            if (_number == _questionsEntities.Length)
            {
                Debug.Log("It is end");
                return null;
            }

            var questionView = Object.Instantiate(_questionConfiguration.QuestionView);

            var question = new Question(questionView, _questionConfiguration.QuestionModel, _correctAnswerCounter,
                _questionsEntities[_number]);

            _number++;

            return question;
        }

        private void GetQuestionArray()
        {
            var jsonLoader = new JsonLoader();
            _questionsEntities = jsonLoader.LoadFromJson().questions;
        }
    }
}
