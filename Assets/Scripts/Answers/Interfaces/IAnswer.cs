using System;
using UnityEngine;

namespace Answers.Interfaces
{
    public interface IAnswer
    {
        event Action<bool> OnAnswerClicked;
        Transform AnswerTransform { get; }
        void SetAnswerText(string text);
        bool IsCorrect { get; set; }
    }
}


