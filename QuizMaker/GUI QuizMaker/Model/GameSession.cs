namespace QuizMaker.GUI_QuizMaker.Model
{
    public class GameSession
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Player Player { get; set; }
        public Quiz Quiz { get; set; }
        public List<Question> SelectedQuestions { get; private set; } = new();
        public int Score { get; private set; }
        public Dictionary<Question, AnswerOption> AnswersGiven { get; set; } = new();
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public DateTime Duration { get; private set; }
        public bool IsCompleted { get; private set; }
    }
}
