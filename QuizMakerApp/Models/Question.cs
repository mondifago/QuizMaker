using System.ComponentModel.DataAnnotations;

namespace QuizMakerApp.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; } = string.Empty;

        public List<AnswerOption> Options { get; set; } = new();

        public int CorrectAnswerId { get; set; }

        public AnswerOption? CorrectAnswer { get; set; }
    }
}
