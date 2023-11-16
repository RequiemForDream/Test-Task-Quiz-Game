using System;
using UnityEngine;

namespace Questions
{
    [Serializable]
    public struct QuestionModel
    {
        [SerializeField] private int _pointsToAdd;
        [SerializeField] private string _correctAnswerText;
        [SerializeField] private string _wrongAnswerText;
        [SerializeField] private Sprite _correctAnswerSprite;
        [SerializeField] private Sprite _wrongAnswerSprite;

        public int PointToAdd => _pointsToAdd;
        public string CorrectAnswerText => _correctAnswerText;
        public string WrongAnswerText => _wrongAnswerText;
        public Sprite CorrectAnswerSprite => _correctAnswerSprite;
        public Sprite WrongAnswerSprite => _wrongAnswerSprite;  
    }
}