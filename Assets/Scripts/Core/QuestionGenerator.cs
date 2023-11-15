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

        private List<IQuestion> _questions = new List<IQuestion>();
        private IFactory<IQuestion> _questionFactory;

        public QuestionGenerator( Transform questionCntainer,
            QuestionConfiguration questionConfiguration)
        {
            _questionContainer = questionCntainer;
            _questionConfiguration = questionConfiguration;
            CreateQuestionFactory();
            CreateQuestion();
        }

        private void CreateQuestionFactory()
        {
            _questionFactory = new QuestionFactory(_questionConfiguration);
        }

        private void CreateQuestion()
        {
            var question = _questionFactory.Create();
            _questions.Add(question);
            question.QuestionTransform.SetParent(_questionContainer, false);
        }
    }
}

