using System;
namespace QuizMaker
{
	public class Quiz
	{
        public int QuestionNumber { get; set; }
        public string Question { get; set; }
        public List<string> AnswerOptions { get; set; } 
        public int CorrectAnswer { get; set; }

        public void SetQuestionNumber(int number)
        {
            QuestionNumber = number;
        }

        public void SetQuestion(string question)
        {
            Question = question;
        }

        public Quiz()
        {
            AnswerOptions = new List<string>();
        }

        public void SetCorrectAnswer(int correctAnswer)
        {
            CorrectAnswer = correctAnswer;
        }
        
    }
}

