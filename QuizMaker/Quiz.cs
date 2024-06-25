using System;
namespace QuizMaker
{
	public class Quiz
	{
        public int QuestionNumber { get; private set; }
        public string Question { get; private set; }
        public string AnswerOption1 { get; private set; }
        public string AnswerOption2 { get; private set; }
        public string AnswerOption3 { get; private set; }
        public string AnswerOption4 { get; private set; }
        public int CorrectAnswer { get; private set; }


        public void InputQuestion()
        {
            Console.Write("Enter Question Number: ");
            QuestionNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter the Question: ");
            Question = Console.ReadLine();

            Console.Write("Enter Answer Option 1: ");
            AnswerOption1 = Console.ReadLine();

            Console.Write("Enter Answer Option 2: ");
            AnswerOption2 = Console.ReadLine();

            Console.Write("Enter Answer Option 3: ");
            AnswerOption3 = Console.ReadLine();

            Console.Write("Enter Answer Option 4: ");
            AnswerOption4 = Console.ReadLine();

            Console.Write("Enter the Correct Answer (1/2/3/4): ");
            CorrectAnswer = int.Parse(Console.ReadLine());
        }

    }
}

