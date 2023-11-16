using Factories.Interfaces;
using UI;
using Object = UnityEngine.Object;

namespace Factories
{
    public class QuestionResultScreenFactory : IFactory<IQuestionResultScreen>
    {
        private readonly QuestionResultScreenConfiguration _questionResultScreenConfiguration;

        public QuestionResultScreenFactory(QuestionResultScreenConfiguration questionResultScreenConfiguration)
        {
            _questionResultScreenConfiguration = questionResultScreenConfiguration;
        }

        public IQuestionResultScreen Create()
        {
            var screen = Object.Instantiate(_questionResultScreenConfiguration.QuestionResultScreenPrefab);

            return screen;
        }
    }
}
