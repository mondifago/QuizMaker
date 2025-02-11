using System.ComponentModel.DataAnnotations;

namespace QuizMakerApp.Models
{
    public class AnswerOption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Text { get; set; } = string.Empty;
        public int QuestionId { get; set; }

        public Question Question { get; set; } = null!;
    }
}
