using System;
using UnityEngine;

namespace UI
{
    public interface IQuestionResultScreen
    {
        event Action OnNextAnswerButtonClicked;
        void SetParameters(string answerTextDisplay, Sprite answerIamgeDisplay, Transform parent);
    }
}
