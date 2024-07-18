using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class QuizMakerLogic
    {
        public List<Quiz> quizzes;
        public Random random = new Random();
        public List<int> userAnswerList;
        public XmlSerializer writer = new XmlSerializer(typeof(List<Quiz>));
        public XmlSerializer reader = new XmlSerializer(typeof(List<Quiz>));

        public QuizMakerLogic()
        {
            quizzes = new List<Quiz>();
            userAnswerList = new List<int>();
        }

        public List<Quiz> GetQuizzes()
        {
            return quizzes;
        }

        public void StoreInputtedQuestions()
        { 
            using (FileStream file = File.Create(QuizMakerConstants.PATH))
            {
                writer.Serialize(file, quizzes);
            }
        }

        public void FetchInputtedQuestions()
        {
            if (File.Exists(QuizMakerConstants.PATH))
            {
                using (FileStream file = File.OpenRead(QuizMakerConstants.PATH))
                {
                    quizzes = reader.Deserialize(file) as List<Quiz>;
                }
            }
        }

        public List<Quiz> RandomlySelectQuizQuestions()
        {
            return quizzes.OrderBy(x => random.Next()).Take(QuizMakerConstants.NUMBER_OF_QUESTIONS_PER_SESSION).ToList();
        }

        public void AddUserAnswer(int userAnswer)
        {
            userAnswerList.Add(userAnswer);
        }
    }
}