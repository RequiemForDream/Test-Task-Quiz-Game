using System;
using System.IO;
using UnityEngine;

namespace Utilities
{
    public class JsonLoader
    {
        public QuestionsList LoadFromJson()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            var _filePath = Path.Combine(Application.persistentDataPath, _fileName);
#else
            var _filePath = Path.Combine(Application.dataPath, DataClass.JsonFileName);
#endif
            var json = File.ReadAllText(_filePath);

            var questions = JsonUtility.FromJson<QuestionsList>(json);

            return questions;
        }
    }

    public struct QuestionsList
    {
        public QuestionEntity[] questions;
    }

    [Serializable]
    public struct QuestionEntity
    {
        public string question;
        public AnswerEntity[] answers;
        public string background;
    }

    [Serializable]
    public struct AnswerEntity
    {
        public string text;
        public bool correct;
    }
}

