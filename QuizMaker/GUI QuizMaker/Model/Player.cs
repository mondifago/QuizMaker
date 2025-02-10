namespace QuizMaker.GUI_QuizMaker.Model
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int TotalScore { get; set; }
    }
}
