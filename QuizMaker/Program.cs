using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load quizzes from XML file if it exists
            List<Quiz> quizList;
            var path = @"../../../Quizlist.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));

            if (File.Exists(path))
            {
                using (FileStream file = File.OpenRead(path))
                {
                    quizList = serializer.Deserialize(file) as List<Quiz>;
                }
            }
            else
            {
                quizList = new List<Quiz>();
            }

            // Instantiate the UI class and display the menu
            QuizMakerUI quizMakerUI = new QuizMakerUI(quizList);
            quizMakerUI.DisplayProgramMenu();

            // Save quizzes back to XML file on exit
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, quizList);
            }
        }
    }
}
