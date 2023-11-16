using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace UI
{
    public class QuestionResultScreen : Screen, IQuestionResultScreen
    {
        [SerializeField] private Button _nextQuestionButton;
        [SerializeField] private TMP_Text _answerTextDisplay;
        [SerializeField] private Image _answerImageDisplay;

        public event Action OnNextAnswerButtonClicked;

        public override void Awake()
        {
            Extensions.Subscribe(_nextQuestionButton, NextAnswerButtonClicked);
        }

        public void SetParameters(string answerTextDisplay, Sprite answerIamgeDisplay, Transform parent)
        {
            transform.SetParent(parent, false);
            _answerImageDisplay.sprite = answerIamgeDisplay;
            _answerTextDisplay.text = answerTextDisplay;
        }

        private void NextAnswerButtonClicked()
        {
            OnNextAnswerButtonClicked?.Invoke();
        }
    }
}

