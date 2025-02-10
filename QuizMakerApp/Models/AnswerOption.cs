namespace QuizMakerApp.Models
{
    public class AnswerOption
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Text { get; set; }
    }
}
