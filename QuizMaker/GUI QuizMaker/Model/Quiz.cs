namespace QuizMaker.GUI_QuizMaker.Model
{
    public class Quiz
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public List<Question> QuestionPool { get; set; } = new();
        public int TimeLimitSeconds { get; set; }
    }
}
