using Microsoft.EntityFrameworkCore;
using QuizMakerApp.Models;

namespace QuizMakerApp.Data
{
    public class QuizMakerAppContext : DbContext
    {
        public QuizMakerAppContext(DbContextOptions<QuizMakerAppContext> options)
            : base(options)
        {
        }

        public DbSet<QuizMakerApp.Models.Quiz> Quiz { get; set; } = default!;
        public DbSet<QuizMakerApp.Models.Question> Question { get; set; } = default!;
        public DbSet<QuizMakerApp.Models.Player> Player { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Question and AnswerOption relationship
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Correct Answer configuration
            modelBuilder.Entity<Question>()
                .HasOne(q => q.CorrectAnswer)
                .WithOne()
                .HasForeignKey<Question>(q => q.CorrectAnswerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Player email unique index
            modelBuilder.Entity<Player>()
                .HasIndex(p => p.Email)
                .IsUnique();

            // Additional constraints and configurations
            modelBuilder.Entity<Question>()
                .Property(q => q.Text)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<AnswerOption>()
                .Property(a => a.Text)
                .IsRequired()
                .HasMaxLength(300);

            modelBuilder.Entity<Player>()
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Player>()
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}
