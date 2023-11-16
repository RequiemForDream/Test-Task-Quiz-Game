using Counters;
using Factories;
using Factories.Interfaces;
using Questions;
using Questions.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class QuestionGenerator
    {
        private readonly Transform _questionContainer;
        private readonly QuestionConfiguration _questionConfiguration;
        private readonly CorrectAnswersCounter _correctAnswersCounter;

        private List<IQuestion> _questions = new List<IQuestion>();
        private IFactory<IQuestion> _questionFactory;

        public QuestionGenerator(Transform questionCntainer, QuestionConfiguration questionConfiguration,
            CorrectAnswersCounter correctAnswerCounter)
        {
            _questionContainer = questionCntainer;
            _questionConfiguration = questionConfiguration;
            _correctAnswersCounter = correctAnswerCounter;
            
            Initialize();
        }

        private void Initialize()
        {
            CreateQuestionFactory();
            CreateQuestion();
        }

        private void CreateQuestion()
        {
            var question = _questionFactory.Create();
            question.OnNextQuestionButtonClicked += CreateQuestion;
            _questions.Add(question);
            question.QuestionTransform.SetParent(_questionContainer, false);
        }

        private void CreateQuestionFactory()
        {
            _questionFactory = new QuestionFactory(_questionConfiguration, _correctAnswersCounter);
        }
    }
}

