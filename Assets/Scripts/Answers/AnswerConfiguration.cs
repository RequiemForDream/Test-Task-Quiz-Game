using UnityEngine;

namespace Answers
{
    [CreateAssetMenu(fileName = "Answer Configuration", menuName = "Gameplay configrutaions / New Answer Configuration")]
    public class AnswerConfiguration : ScriptableObject
    {
        [SerializeField] private AnswerView _answerView;
        [SerializeField] private AnswerModel _answerModel;

        public AnswerView AnswerView => _answerView;
        public AnswerModel AnswerModel => _answerModel;
    }
}
