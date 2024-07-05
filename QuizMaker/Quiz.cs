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

        public void SetQuestionNumber(int number)
        {
            QuestionNumber = number;
        }

        public void SetQuestion(string question)
        {
            Question = question;
        }

        public void SetCorrectAnswer(int correctAnswer)
        {
            CorrectAnswer = correctAnswer;
        }



        

        
    }
}

