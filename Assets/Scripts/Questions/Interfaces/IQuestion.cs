using System;
using UnityEngine;

namespace Questions.Interfaces
{
    public interface IQuestion
    {
        event Action OnNextQuestionButtonClicked;
        Transform QuestionTransform { get; }
    }
}
