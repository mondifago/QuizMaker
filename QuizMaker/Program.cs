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
            // Instantiate the logic class
            QuizMakerLogic quizMakerLogic = new QuizMakerLogic();
            quizMakerLogic.FetchInputtedQuestions();

            // Instantiate the UI class and display the menu
            QuizMakerUI quizMakerUI = new QuizMakerUI(quizMakerLogic);
            quizMakerUI.DisplayProgramMenu();

            // Save quizzes back to XML file on exit
            quizMakerLogic.StoreInputtedQuestions();
        }
    }
}
