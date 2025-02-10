namespace QuizMaker.GUI_QuizMaker.Model
{
    public class AnswerOption
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Text { get; set; }
    }
}
