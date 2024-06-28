using System;
namespace QuizMaker
{
	public class Quiz
	{
        public int QuestionNumber { get; private set; }
        public string Question { get; private set; }
        public List<string> AnswerOptions { get; private set; } 
        public int CorrectAnswer { get; private set; }

        public Quiz()
        {
            AnswerOptions = new List<string>(); 
        }

        public void InputQuestion()
        {
            Console.Write("Enter Question Number: ");
            QuestionNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter the Question: ");
            Question = Console.ReadLine();

            InputQuestionOptions();

            Console.Write("Enter the Correct Answer (1/2/3/4): ");
            CorrectAnswer = int.Parse(Console.ReadLine());
        }

        public void InputQuestionOptions()
        {
            Console.Write("Enter the number of Options you want to input: ");
            int numberOfOptions = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfOptions; i++)
            {
                Console.Write($"Enter Option {i + 1}: ");
                string option = Console.ReadLine();
                AnswerOptions.Add(option); 
                Console.WriteLine($"{i + 1}: {option}");
            }
        }


        public void StoreQuestionsInputted()
        {

        }

        public void DisplayAllQuestionsInputted()
        {

        }

        public void DisplayUserTestQuestions()
        {

        }

        public void DisplayUserTestScore() { }

        public void RecordUsersTestResult() { }

        public void DisplayUserTestResult() { }

        public void RecordUserTestHistory() { }

        public void DisplayUserTestHistory() { }
    }
}

