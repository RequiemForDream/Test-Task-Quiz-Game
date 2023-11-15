using UnityEngine;

namespace Answers
{
    [CreateAssetMenu]
    public class AnswerConfiguration : ScriptableObject
    {
        [SerializeField] private AnswerView _answerView;
        [SerializeField] private AnswerModel _answerModel;

        public AnswerView AnswerView => _answerView;
        public AnswerModel AnswerModel => _answerModel;
    }
}
