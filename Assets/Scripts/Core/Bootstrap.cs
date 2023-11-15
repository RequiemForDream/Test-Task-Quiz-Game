using Questions;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private QuestionConfiguration _questionConfiguration;
        [SerializeField] private Transform _questionContainer;

        private void Awake()
        {
            var questionGenerator = BindQuestionGenerator();
        }

        private QuestionGenerator BindQuestionGenerator()
        {
            return new QuestionGenerator(_questionContainer, _questionConfiguration);
        }
    }
}

