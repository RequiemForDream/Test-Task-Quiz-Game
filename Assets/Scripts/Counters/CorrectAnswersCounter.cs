using System;
using UnityEngine;

namespace Counters
{
    public class CorrectAnswersCounter
    {
        public event Action<int> OnCorrectAnswerClicked;
        public int _correctAnswersCount;

        public void AddValue(int value)
        {
            _correctAnswersCount += value;
            Debug.Log(_correctAnswersCount);
            OnCorrectAnswerClicked?.Invoke(_correctAnswersCount);
        }
    }
}
