using System;
using System.IO;
using UnityEngine;

namespace Core
{
    public class TestJsonLoader : MonoBehaviour
    {
        private string _fileName = "JsonQuiz.json";
        private string _filePath;

        public QuestionsList Questions = new QuestionsList();

        private void Awake()
        {
            //Questions = JsonUtility.FromJson<QuestionsList>(TextJson.text);
#if UNITY_ANDROID && !UNITY_EDITOR
            _filePath = Path.Combine(Application.persistentDataPath, _fileName);
#else
            _filePath = Path.Combine(Application.dataPath, _fileName);
#endif
            var json = File.ReadAllText(_filePath);

            Questions = JsonUtility.FromJson<QuestionsList>(json);
        }
    }

    [Serializable]
    public struct AnswerEntity
    {
        public string text;
        public bool correct;
    }

    [Serializable]
    public struct QuestionEntity
    {
        public string question;
        public AnswerEntity[] answers;
        public string background;
    }

    [Serializable]
    public struct QuestionsList
    {
        public QuestionEntity[] questions;
    }
}

