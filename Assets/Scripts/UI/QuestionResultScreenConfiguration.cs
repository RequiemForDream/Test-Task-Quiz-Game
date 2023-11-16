using UnityEngine;

namespace UI
{
    [CreateAssetMenu]
    public class QuestionResultScreenConfiguration : ScriptableObject
    {
        [SerializeField] private QuestionResultScreen _questionResultScreenPrefab;
        public QuestionResultScreen QuestionResultScreenPrefab => _questionResultScreenPrefab;
    }
}

