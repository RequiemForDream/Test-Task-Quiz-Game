using Factories.Interfaces;
using Questions.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public class QuestionGenerator
    {
        private readonly Transform _questionContainer;
        private readonly IFactory<IQuestion> _questionFactory;

        private List<IQuestion> _questions = new List<IQuestion>();
        
        public QuestionGenerator(Transform questionCntainer, IFactory<IQuestion> questionFacttory)
        {
            _questionContainer = questionCntainer;
            _questionFactory = questionFacttory;
            
            //Initialize();
        }

        public void Initialize()
        {
            CreateQuestion();
        }

        private void CreateQuestion()
        {
            var question = _questionFactory.Create();
            if (question != null)
            {
                RemoveQuestion();
                question.OnNextQuestionButtonClicked += CreateQuestion;
                _questions.Add(question);
                question.QuestionTransform.SetParent(_questionContainer, false);
            }
        }

        private void RemoveQuestion()
        {
            if (_questions.Count > 0)
            {
                var question = _questions.Last();
                question.OnNextQuestionButtonClicked -= CreateQuestion;
                _questionFactory.Reclaim(question.QuestionTransform.gameObject);
                _questions.Remove(question);
            }
        }
        
        public void Reset()
        {
            RemoveQuestion();
        }
    }
}

