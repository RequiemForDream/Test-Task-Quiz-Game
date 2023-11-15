using Factories.Interfaces;
using Questions;
using Questions.Interfaces;
using Object = UnityEngine.Object;

namespace Factories
{
    public class QuestionFactory : IFactory<IQuestion>
    {
        private readonly QuestionConfiguration _questionConfiguration;

        public QuestionFactory(QuestionConfiguration questionConfiguration)
        {
            _questionConfiguration = questionConfiguration;
        }

        public IQuestion Create()
        {
            var questionView = Object.Instantiate(_questionConfiguration.QuestionView);

            var question = new Question(questionView, _questionConfiguration.QuestionModel);

            return question;
        }
    }
}
