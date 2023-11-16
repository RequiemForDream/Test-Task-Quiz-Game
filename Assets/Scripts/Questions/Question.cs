using Answers.Interfaces;
using Counters;
using Factories;
using Factories.Interfaces;
using Questions.Interfaces;
using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Utilities;

namespace Questions
{
    public class Question : IQuestion
    {
        public event Action OnNextQuestionButtonClicked;

        private readonly QuestionView _questionView;
        private readonly QuestionModel _questionModel;
        private readonly QuestionEntity _questionEntity;
        private readonly CorrectAnswersCounter _correctAnswersCounter;
        private readonly IFactory<IQuestionResultScreen> _screenResultFactory;
        private readonly IFactory<IAnswer> _answerFactory;

        private List<IAnswer> _answers = new List<IAnswer>();

        public Transform QuestionTransform
        {
            get
            {
                return _questionView.transform;
            }
        }

        public Question(QuestionView questionView, QuestionModel questionModel, CorrectAnswersCounter correctAnswersCounter, 
            QuestionEntity questionEntity, IFactory<IQuestionResultScreen> questionResultScreenFactory, 
            IFactory<IAnswer> answerFactory)
        {
            _questionView = questionView;
            _questionEntity = questionEntity;
            _questionModel = questionModel;
            _correctAnswersCounter = correctAnswersCounter;
            _answerFactory = answerFactory;
            _screenResultFactory = questionResultScreenFactory;

            Initialize();
        }

        private void Initialize()
        {
            _questionView.OnDestroyHandler += Destroy;

            CreateAnswers();
            SetQuestionParameters();
        }

        private void CreateAnswers()
        {
            for (int i = 0; i < _questionEntity.answers.Length; i++)
            {
                var answer = _answerFactory.Create();
                answer.OnAnswerClicked += CheckAnswer;
                _answers.Add(answer);
                var answerText = _questionEntity.answers[i].text;
                var isCorrect = _questionEntity.answers[i].correct;

                FillAnswer(answer, answerText, isCorrect);
            }
        }

        private void FillAnswer(IAnswer answer, string answerText, bool isCorrect)
        {
            answer.AnswerTransform.SetParent(_questionView.AnswerContainer, false);
            answer.SetAnswerText(answerText);
            answer.IsCorrect = isCorrect;
        }

        private void SetQuestionParameters()
        {
            _questionView.QuestionText.text = _questionEntity.question;
            _questionView.QuestionBackground.sprite = Resources.Load<Sprite>("Sprites/Rabbit");
        }

        private void CheckAnswer(bool IsCorrect)
        {
            if (IsCorrect)
            {
                _correctAnswersCounter.AddValue(_questionModel.PointToAdd);
                ShowResult(_questionModel.CorrectAnswerText, _questionModel.CorrectAnswerSprite);
            }
            else
            {
                ShowResult(_questionModel.WrongAnswerText, _questionModel.WrongAnswerSprite);
            }
        }

        private void ShowResult(string answerCorrectText, Sprite answerCorrectSprite)
        {
            var screen = _screenResultFactory.Create();
            screen.OnNextAnswerButtonClicked += NextQuestionClick;
            screen.SetParameters(answerCorrectText, answerCorrectSprite, QuestionTransform);
        }

        private void NextQuestionClick()
        {
            OnNextQuestionButtonClicked?.Invoke();
        }

        private void Destroy()
        {
            _questionView.OnDestroyHandler -= Destroy;
            foreach (var answer in _answers)
            {
                answer.OnAnswerClicked -= CheckAnswer;
            }
        }
    }
}
