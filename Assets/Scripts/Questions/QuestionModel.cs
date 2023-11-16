using Answers;
using System;
using UI;
using UnityEngine;

namespace Questions
{
    [Serializable]
    public struct QuestionModel
    {
        [SerializeField] private AnswerConfiguration _answerConfiguration;
        [SerializeField] private QuestionResultScreenConfiguration _questionResultScreenConfiguration;
        [SerializeField] private int _pointsToAdd;
        [SerializeField] private string _correctAnswerText;
        [SerializeField] private string _wrongAnswerText;
        [SerializeField] private Sprite _correctAnswerSprite;
        [SerializeField] private Sprite _wrongAnswerSprite;
        public AnswerConfiguration AnswerConfiguration => _answerConfiguration;
        public QuestionResultScreenConfiguration QuestionResultScreenConfiguration => _questionResultScreenConfiguration;
        public int PointToAdd => _pointsToAdd;
        public string CorrectAnswerText => _correctAnswerText;
        public string WrongAnswerText => _wrongAnswerText;
        public Sprite CorrectAnswerSprite => _correctAnswerSprite;
        public Sprite WrongAnswerSprite => _wrongAnswerSprite;  
    }
}