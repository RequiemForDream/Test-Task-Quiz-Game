using Core.Interfaces;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Answers
{
    public class AnswerView : MonoBehaviour, IPointerClickHandler, IDestroyable
    {
        public event Action OnAnswerClicked;
        public event Action OnDestroyHandler;

        public TMP_Text AnswerText;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnAnswerClicked?.Invoke();
        }

        private void OnDestroy()
        {
            OnDestroyHandler?.Invoke();
        }
    }
}
