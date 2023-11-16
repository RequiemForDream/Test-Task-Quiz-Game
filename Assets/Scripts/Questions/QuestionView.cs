using Core.Interfaces;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Questions
{
    public class QuestionView : MonoBehaviour, IDestroyable
    {
        public Transform AnswerContainer;
        public TMP_Text QuestionText;
        public Image QuestionBackground;

        public event Action OnDestroyHandler;

        private void OnDestroy()
        {
            OnDestroyHandler?.Invoke();
        }
    }
}
