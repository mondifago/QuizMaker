using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class QuizMakerUI
    {
        private List<Quiz> selectedQuestions;
        private QuizMakerLogic quizMakerLogic;
        private bool exitProgram = false;
        public int correct;
        public int incorrect;

        public QuizMakerUI(QuizMakerLogic quizMakerLogic)
        {
            selectedQuestions = new List<Quiz>();
            this.quizMakerLogic = quizMakerLogic;
        }

        public void DisplayProgramMenu()
        {
            while (!exitProgram)
            {
                Console.Clear();
                Console.WriteLine("************************ Welcome to Quiz Maker *************************\n");
                Console.WriteLine("Menu:\n" +
                                  "1. Admin Login\n" +
                                  "2. Admin View All Questions\n" +
                                  "3. Take Quiz\n" +
                                  "4. View Answers to quiz\n" +
                                  "5. Exit program\n\n");
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
                            DisplayUserTestQuestions();
                            break;

                        case MenuOption.ViewAnswersToQuiz:
                            DisplayUserTestResult();
                            break;

                        case MenuOption.ExitProgram:
                            ExitProgram();
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

        public void AddMultipleQuestions()
        {
            Console.WriteLine($"\nTotal number of Questions stored already = {quizMakerLogic.quizzes.Count}");
            int numberOfQuestions = PromptForValidNumber("How many questions would you like to add? \t");

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine($"\nAdding Question {i + 1} of {numberOfQuestions}");

                Quiz quiz = new Quiz();
                InputQuestionNumber(quiz);
                InputQuizQuestion(quiz);
                InputQuestionOptions(quiz);
                InputQuestionCorrectAnswer(quiz);
                quizMakerLogic.quizzes.Add(quiz);

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
            quizMakerLogic.StoreInputtedQuestions();

            Console.WriteLine("All questions have been added.");
            PromptReturnToMenu();
            DisplayProgramMenu();
        }

        public void InputQuestionNumber(Quiz quiz)
        {
            Console.WriteLine($"You are expected to start from {quizMakerLogic.quizzes.Count + 1}");
            int questionNumber = PromptForValidNumber("Enter Question Number: ");
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
            int numberOfOptions = PromptForValidNumber("Enter the number of Options you want to input: ");

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
            int correctAnswer = PromptForValidNumberAndRange("Enter the Correct Answer (" + string.Join("/", Enumerable.Range(1, quiz.AnswerOptions.Count)) + "): ",1, quiz.AnswerOptions.Count);
            quiz.SetCorrectAnswer(correctAnswer);
        }

        public void DisplayAllQuestionsInputted()
        {
            quizMakerLogic.FetchInputtedQuestions();
            Console.Clear();
            Console.WriteLine("********************* All Questions Inputted *********************\n");

            foreach (var quiz in quizMakerLogic.quizzes)
            {
                DisplayQuizQuestionsAndAnswerOptions(quiz);
                Console.WriteLine($"Correct Answer: Option {quiz.CorrectAnswer}\n");
                Console.WriteLine("----------------------------------------------------------\n");
            }
            PromptReturnToMenu();
            DisplayProgramMenu();
        }

        public void DisplayUserTestQuestions()
        {
            quizMakerLogic.FetchInputtedQuestions();
            correct = 0;
            incorrect = 0;
            quizMakerLogic.userAnswerList.Clear();

            Console.Clear();
            DisplayQuizInstructions();
            Console.ReadKey();
            Console.Clear();

            selectedQuestions = quizMakerLogic.RandomlySelectQuizQuestions();

            foreach (var quiz in selectedQuestions)
            {
                DisplayQuizQuestionsAndAnswerOptions(quiz);
                int userAnswer = PromptUserToInputAnswer(quiz);
                quizMakerLogic.AddUserAnswer(userAnswer);
                ValidateAndDisplayUserAnswer(quiz, userAnswer);
                Console.WriteLine("Press any key to continue to the next question...");
                Console.ReadKey();
                Console.Clear();
            }
            DisplayUserQuizScore();
            PromptReturnToMenu();
            DisplayProgramMenu();
        }

        public void DisplayQuizInstructions()
        {
            Console.WriteLine("********************* Welcome To General IQ Quiz *********************\n");
            Console.WriteLine($"Quiz Instruction: This Quiz contains {QuizMakerConstants.NUMBER_OF_QUESTIONS_PER_SESSION} Questions, you need to answer {QuizMakerConstants.PASS_SCORE} correctly to pass.");
            Console.WriteLine("This is a multiple choice answer quiz, select the correct option number from the options\n");
            Console.WriteLine("When you are ready, Press any key to start.... ");
        }

        public void DisplayUserQuizScore()
        {
            Console.WriteLine("Quiz completed!");
            Console.WriteLine($"Your Score is {correct} / {QuizMakerConstants.NUMBER_OF_QUESTIONS_PER_SESSION}\n");
            if (correct >= QuizMakerConstants.PASS_SCORE)
            {
                Console.WriteLine("CONGRATULATIONS!!, you passed the quiz!");
            }
            else
            {
                Console.WriteLine("Sorry, you did not pass the quiz. Better luck next time!");
            }
        }

        public void DisplayQuizQuestionsAndAnswerOptions(Quiz quiz)
        {
            Console.WriteLine($"Question Number: {quiz.QuestionNumber}");
            Console.WriteLine($"Question: {quiz.Question}");
            Console.WriteLine("Options:");
            for (int j = 0; j < quiz.AnswerOptions.Count; j++)
            {
                Console.WriteLine($"{j + 1}: {quiz.AnswerOptions[j]}");
            }
        }

        private int PromptUserToInputAnswer(Quiz quiz)
        {
            return PromptForValidNumberAndRange("Enter the Correct Answer (" + string.Join("/", Enumerable.Range(1, quiz.AnswerOptions.Count)) + "): ",1, quiz.AnswerOptions.Count);
        }

        public void ValidateAndDisplayUserAnswer(Quiz quiz, int userAnswer)
        {
            if (userAnswer == quiz.CorrectAnswer)
            {
                Console.WriteLine("CORRECT!!!");
                correct++;
            }
            else
            {
                Console.WriteLine("INCORRECT");
                incorrect++;
            }
        }

        public void DisplayUserTestResult()
        {
            if (selectedQuestions.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("You Have To Take A Quiz First Buddy!\n\n");
                PromptReturnToMenu();
                DisplayProgramMenu();
                return;
            }

            Console.Clear();
            Console.WriteLine("********************* User Quiz Answers *********************\n");

            for (int i = 0; i < selectedQuestions.Count; i++)
            {
                var attemptedQuiz = selectedQuestions[i];
                int userAnswer = quizMakerLogic.userAnswerList[i];

                DisplayQuizQuestionsAndAnswerOptions(attemptedQuiz);
                Console.WriteLine($"Correct Answer: Option {attemptedQuiz.CorrectAnswer}");
                Console.WriteLine($"Your Answer: Option {userAnswer}\n");
                Console.WriteLine("----------------------------------------------------------\n");
            }
            PromptReturnToMenu();
            DisplayProgramMenu();
        }

        private int PromptForValidNumber(string promptMessage)
        {
            Console.Write(promptMessage);
            string input = Console.ReadLine();
            int validNumber;

            while (!int.TryParse(input, out validNumber))
            {
                Console.WriteLine("\nInvalid input. Please enter a valid number.");
                Console.Write(promptMessage);
                input = Console.ReadLine();
            }

            return validNumber;
        }

        private int PromptForValidNumberAndRange(string promptMessage, int min, int max)
        {
            Console.Write(promptMessage);
            string input = Console.ReadLine();
            int validNumber;

            while (!int.TryParse(input, out validNumber) || validNumber < min || validNumber > max)
            {
                Console.WriteLine($"\nInvalid input. Please enter a valid number between {min} and {max}.");
                Console.Write(promptMessage);
                input = Console.ReadLine();
            }

            return validNumber;
        }

        public void PromptReturnToMenu()
        {
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        private void ExitProgram()
        {
            quizMakerLogic.StoreInputtedQuestions();
            Console.WriteLine("Quizzes have been saved. Exiting the program...");
            exitProgram = true;
        }
    }
}