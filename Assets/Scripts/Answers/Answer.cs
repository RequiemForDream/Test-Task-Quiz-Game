using Answers.Interfaces;
using System;
using UnityEngine;

namespace Answers
{
    public class Answer : IAnswer
    {
        public event Action<bool> OnAnswerClicked;

        private readonly AnswerView _answerView;
        private readonly AnswerModel _answerModel;

        public Transform AnswerTransform
        {
            get
            {
                return _answerView.transform;
            }
        }

        public bool IsCorrect
        {
            get
            {
                return _isCorrect;
            }
            set
            {
                _isCorrect = value; 
            }
        }

        private bool _isCorrect;

        public Answer(AnswerView answerView, AnswerModel answerModel)
        {
            _answerView = answerView;
            _answerModel = answerModel;
            Initialize();
        }

        private void Initialize()
        {
            _answerView.OnAnswerClicked += AnswerClicked;
            _answerView.OnDestroyHandler += Destroy;
        }

        private void AnswerClicked()
        {
            OnAnswerClicked?.Invoke(IsCorrect);
        }

        public void SetAnswerText(string text)
        {
            _answerView.AnswerText.text = text;
        }

        private void Destroy()
        {
            _answerView.OnDestroyHandler -= Destroy;
            _answerView.OnAnswerClicked -= AnswerClicked;
        }
    }
}
