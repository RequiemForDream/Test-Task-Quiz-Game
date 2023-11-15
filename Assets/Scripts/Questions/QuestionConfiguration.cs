using UnityEngine;

namespace Questions
{
    [CreateAssetMenu]
    public class QuestionConfiguration : ScriptableObject
    {
        [SerializeField] private QuestionView _questionView;
        [SerializeField] private QuestionModel _questionModel;

        public QuestionView QuestionView => _questionView;
        public QuestionModel QuestionModel => _questionModel;
    }
}
