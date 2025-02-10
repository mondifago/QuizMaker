namespace QuizMaker.GUI_QuizMaker.Model
{
    public class Quiz
    {
        public int QuestionNumber { get; set; }
        public string Question { get; set; }
        public List<string> AnswerOptions { get; set; }
        public int CorrectAns { get; set; }
        public int TimeLimitSeconds { get; set; }
    }
}
