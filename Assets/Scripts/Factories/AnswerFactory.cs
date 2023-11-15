using Answers;
using Answers.Interfaces;
using Factories.Interfaces;
using Object = UnityEngine.Object;

namespace Factories
{
    public class AnswerFactory : IFactory<IAnswer>
    {
        private readonly AnswerConfiguration _answerConfiguration;

        public AnswerFactory(AnswerConfiguration answerConfiguration)
        {
            _answerConfiguration = answerConfiguration;
        }

        public IAnswer Create()
        {
            var answerView = Object.Instantiate(_answerConfiguration.AnswerView);

            var answer = new Answer(answerView, _answerConfiguration.AnswerModel);

            return answer;
        }
    }
}
