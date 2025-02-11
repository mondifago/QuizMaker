using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace QuizMakerApp.Data
{
    public class QuizMakerAppContextFactory : IDesignTimeDbContextFactory<QuizMakerAppContext>
    {
        public QuizMakerAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuizMakerAppContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=QuizMakerAppContext-f83931ac-f252-4484-9d91-76cdc8cf3f36;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new QuizMakerAppContext(optionsBuilder.Options);
        }
    }
}