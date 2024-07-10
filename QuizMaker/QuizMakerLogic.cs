using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class QuizMakerLogic
    {
        private List<Quiz> quizzes;
        private string path = @"../../../Quizlist.xml";

        public QuizMakerLogic()
        {
            quizzes = new List<Quiz>();
        }

        public List<Quiz> GetQuizzes()
        {
            return quizzes;
        }

        public void StoreInputtedQuestions()
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Quiz>));
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, quizzes);
            }
        }

        public void FetchInputtedQuestions()
        {
            if (File.Exists(path))
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<Quiz>));
                using (FileStream file = File.OpenRead(path))
                {
                    quizzes = reader.Deserialize(file) as List<Quiz>;
                }
            }
        }
    }
}
