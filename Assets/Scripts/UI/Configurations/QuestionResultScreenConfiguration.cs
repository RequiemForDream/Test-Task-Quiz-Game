using UnityEngine;

namespace UI.Configurations
{
    [CreateAssetMenu(fileName = "Question Result Screen Configuration", 
        menuName = "UI Configurations / New Question Result Screen Configuration")]
    public class QuestionResultScreenConfiguration : ScriptableObject
    {
        [SerializeField] private QuestionResultScreen _questionResultScreenPrefab;

        public QuestionResultScreen QuestionResultScreenPrefab => _questionResultScreenPrefab;
    }
}

