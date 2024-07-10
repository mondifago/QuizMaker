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
            // Instantiate the logic class and load quizzes
            QuizMakerLogic quizMakerLogic = new QuizMakerLogic();
            quizMakerLogic.FetchInputtedQuestions();
            List<Quiz> quizList = quizMakerLogic.GetQuizzes();

            // Instantiate the UI class and display the menu
            QuizMakerUI quizMakerUI = new QuizMakerUI(quizList, quizMakerLogic);
            quizMakerUI.DisplayProgramMenu();

            // Save quizzes back to XML file on exit
            quizMakerLogic.StoreInputtedQuestions();
        }
    }
}
