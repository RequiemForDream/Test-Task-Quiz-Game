using Answers;
using System;
using UnityEngine;

namespace Questions
{
    [Serializable]
    public struct QuestionModel
    {
        [SerializeField] private AnswerConfiguration _answerConfiguration;
        [SerializeField] private int _answersAmount;
        public AnswerConfiguration AnswerConfiguration => _answerConfiguration;
        public int AnswersAmount => _answersAmount;
    }
}
