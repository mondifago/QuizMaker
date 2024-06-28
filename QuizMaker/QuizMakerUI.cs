using System;
namespace QuizMaker
{
	public class QuizMakerUI
	{
        public static void DisplayProgramMenu()
        {
            Console.WriteLine("************************ Welcome to Quiz Maker *************************\n");
            Console.WriteLine("Menu:\n" +
                              "1. Admin Login\n" +
                              "2. Admin View All Questions\n" +
                              "3. User Login\n" +
                              "4. View Answers to quiz\n" +
                              "5. User Score Records\n\n");
            Console.Write("Please choose the number of the page you want to visit... ");

            int mode;
            if (int.TryParse(Console.ReadLine(), out mode) && Enum.IsDefined(typeof(MenuOption), mode))
            {
                MenuOption selectedOption = (MenuOption)mode;

                switch (selectedOption)
                {
                    case MenuOption.AdminLogin:
                        Quiz quiz = new Quiz();
                        quiz.InputQuestion();
                        Console.WriteLine("\nQuiz Details:");
                        Console.WriteLine($"Question Number: {quiz.QuestionNumber}");
                        Console.WriteLine($"Question: {quiz.Question}");
                        Console.WriteLine("Options:");
                        for (int i = 0; i < quiz.AnswerOptions.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}: {quiz.AnswerOptions[i]}");
                        }
                        Console.WriteLine($"Correct Answer: Option {quiz.CorrectAnswer}");
                        break;

                    case MenuOption.AdminViewAllQuestions:
                        //quiz.DisplayAllQuestionsInputted();
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

                    default:
                        Console.WriteLine("Invalid input for the correct answer. Please enter a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
        }
    }
}

