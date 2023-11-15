using Answers.Interfaces;
using Factories;
using Questions.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Questions
{
    public class Question : IQuestion
    {
        private readonly QuestionView _questionView;
        private readonly QuestionModel _questionModel;

        private List<IAnswer> _answers = new List<IAnswer>();

        public Transform QuestionTransform
        {
            get
            {
                return _questionView.transform;
            }
        }

        public Question(QuestionView questionView, QuestionModel questionModel)
        {
            _questionView = questionView;
            _questionModel = questionModel;
            CreateAnswers();
        }

        private void CreateAnswers()
        {
            var answerFactory = new AnswerFactory(_questionModel.AnswerConfiguration);
            for (int i = 0; i < _questionModel.AnswersAmount; i++)
            {
                var answer = answerFactory.Create();
                _answers.Add(answer);
                answer.AnswerTransform.SetParent(_questionView.AnswerContainer, false);
            }
        }
    }
}
