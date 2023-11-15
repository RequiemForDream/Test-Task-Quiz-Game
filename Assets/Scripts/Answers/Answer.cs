using Answers.Interfaces;
using UnityEngine;

namespace Answers
{
    public class Answer : IAnswer
    {
        private readonly AnswerView _answerView;
        private readonly AnswerModel _answerModel;

        public Transform AnswerTransform
        {
            get
            {
                return _answerView.transform;
            }
        }

        public Answer(AnswerView answerView, AnswerModel answerModel)
        {
            _answerView = answerView;
            _answerModel = answerModel;
        }
    }
}
