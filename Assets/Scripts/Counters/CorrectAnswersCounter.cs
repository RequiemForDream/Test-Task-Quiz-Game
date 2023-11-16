using System;

namespace Counters
{
    public class CorrectAnswersCounter
    {
        public event Action<int> OnCorrectAnswerClicked;
        private int _correctAnswersCount;

        public void AddValue(int value)
        {
            _correctAnswersCount += value;
            OnCorrectAnswerClicked?.Invoke(_correctAnswersCount);
        }
    }
}
