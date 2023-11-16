using UnityEngine;

namespace Questions
{
    [CreateAssetMenu(fileName = "Question Configuration", menuName = "Gameplay configrutaions / New Question Configuration")]
    public class QuestionConfiguration : ScriptableObject
    {
        [SerializeField] private QuestionView _questionView;
        [SerializeField] private QuestionModel _questionModel;

        public QuestionView QuestionView => _questionView;
        public QuestionModel QuestionModel => _questionModel;
    }
}
