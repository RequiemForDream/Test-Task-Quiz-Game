using UnityEngine;

namespace UI.Configurations
{
    [CreateAssetMenu(fileName = "Canvas Configuration", menuName = "UI Configurations / New Canvas Configuration")]
    public class CanvasConfiguration : ScriptableObject
    {
        [SerializeField] private Canvas _canvasPrefab;

        public Canvas Canvas => _canvasPrefab;
    }
}

