using Factories.Interfaces;
using UI;
using UI.Configurations;
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

        public void Reclaim(Object obj)
        {
            Object.Destroy(obj);
        }
    }
}
