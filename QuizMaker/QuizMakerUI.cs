using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class QuizMakerUI
    {
        private List<Quiz> quizzes;
        private string path = @"../../../Quizlist.xml";

        public QuizMakerUI(List<Quiz> quizzes)
        {
            this.quizzes = quizzes;
        }

        public void DisplayProgramMenu()
        {
            Console.Clear();
            Console.WriteLine("************************ Welcome to Quiz Maker *************************\n");
            Console.WriteLine("Menu:\n" +
                              "1. Admin Login\n" +
                              "2. Admin View All Questions\n" +
                              "3. User Login\n" +
                              "4. View Answers to quiz\n" +
                              "5. User Score Records\n" +
                              "6. Exit program\n\n");
            Console.Write("Please choose the number of the page you want to visit... ");

            int mode;
            if (int.TryParse(Console.ReadLine(), out mode) && Enum.IsDefined(typeof(MenuOption), mode))
            {
                MenuOption selectedOption = (MenuOption)mode;

                switch (selectedOption)
                {
                    case MenuOption.AdminLogin:
                        AddMultipleQuestions();
                        break;

                    case MenuOption.AdminViewAllQuestions:
                        DisplayAllQuestionsInputted();
                        break;

                    case MenuOption.UserLogin:
                        // User login logic here
                        break;

                    case MenuOption.ViewAnswersToQuiz:
                        // View answers to quiz logic here
                        break;

                    case MenuOption.UserScoreRecords:
                        // User score records logic here
                        break;

                    case MenuOption.ExitProgram:
                        // Exit program logic here
                        break;

                    default:
                        Console.WriteLine("Invalid input for the correct answer. Please enter a valid option.");
                        break;
                }
                DisplayProgramMenu();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                DisplayProgramMenu();
            }
        }

        public void AddMultipleQuestions()
        {
            Console.Write("How many questions would you like to add? ");
            int numberOfQuestions = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine($"\nAdding Question {i + 1} of {numberOfQuestions}");

                Quiz quiz = new Quiz();
                InputQuestionNumber(quiz);
                InputQuizQuestion(quiz);
                InputQuestionOptions(quiz);
                InputQuestionCorrectAnswer(quiz);

                quizzes.Add(quiz);

                Console.WriteLine("\nQuiz Details:");
                Console.WriteLine($"Question Number: {quiz.QuestionNumber}");
                Console.WriteLine($"Question: {quiz.Question}");
                Console.WriteLine("Options:");
                for (int j = 0; j < quiz.AnswerOptions.Count; j++)
                {
                    Console.WriteLine($"{j + 1}: {quiz.AnswerOptions[j]}");
                }
                Console.WriteLine($"Correct Answer: Option {quiz.CorrectAnswer}\n");
                Console.WriteLine("Review the question and press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            // Serialize quizzes to XML
            XmlSerializer writer = new XmlSerializer(typeof(List<Quiz>));
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, quizzes);
            }

            Console.WriteLine("All questions have been added. Press any key to return to the main menu...");
            Console.ReadKey();
            DisplayProgramMenu(); // Return to the main menu after adding questions
        }

        public void InputQuestionNumber(Quiz quiz)
        {
            Console.Write("Enter Question Number: ");
            int questionNumber = int.Parse(Console.ReadLine());
            quiz.SetQuestionNumber(questionNumber);
        }

        public void InputQuizQuestion(Quiz quiz)
        {
            Console.Write("Enter the Question: ");
            string question = Console.ReadLine();
            quiz.SetQuestion(question);
        }

        public void InputQuestionOptions(Quiz quiz)
        {
            Console.Write("Enter the number of Options you want to input: ");
            int numberOfOptions = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfOptions; i++)
            {
                Console.Write($"Enter Option {i + 1}: ");
                string option = Console.ReadLine();
                quiz.AnswerOptions.Add(option);
                Console.WriteLine($"{i + 1}: {option}");
            }
        }

        public void InputQuestionCorrectAnswer(Quiz quiz)
        {
            Console.Write("Enter the Correct Answer (" + string.Join("/", Enumerable.Range(1, quiz.AnswerOptions.Count)) + "): ");
            int correctAnswer = int.Parse(Console.ReadLine());
            quiz.SetCorrectAnswer(correctAnswer);
        }

        public void DisplayAllQuestionsInputted()
        {
            // Deserialize quizzes from XML
            XmlSerializer reader = new XmlSerializer(typeof(List<Quiz>));
            using (FileStream file = File.OpenRead(path))
            {
                quizzes = reader.Deserialize(file) as List<Quiz>;
            }

            Console.Clear();
            Console.WriteLine("********************* All Questions Inputted *********************\n");

            foreach (var quiz in quizzes)
            {
                Console.WriteLine($"Question Number: {quiz.QuestionNumber}");
                Console.WriteLine($"Question: {quiz.Question}");
                Console.WriteLine("Options:");
                for (int i = 0; i < quiz.AnswerOptions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {quiz.AnswerOptions[i]}");
                }
                Console.WriteLine($"Correct Answer: Option {quiz.CorrectAnswer}\n");
                Console.WriteLine("----------------------------------------------------------\n");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            DisplayProgramMenu(); // Return to the main menu after displaying questions
        }

        public void DisplayUserTestQuestions() { }

        public void DisplayUserTestScore() { }

        public void DisplayUserTestResult() { }

        public void RecordUserTestHistory() { }

        public void DisplayUserTestHistory() { }
    }

    
}
