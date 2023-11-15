using UnityEngine.Events;
using UnityEngine.UI;

namespace Utilities
{
    public static class Extensions
    {
        public static void Subscribe(Button button, UnityAction unityAction)
        {
            button.onClick.AddListener(unityAction);
        }
    }
}
