namespace QuizMakerApp.Models
{
    public class Question
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Text { get; set; }
        public List<AnswerOption> Options { get; set; } = new();
        public Guid CorrectAnswerId { get; set; }
    }
}
