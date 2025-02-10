using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizMakerApp.Models;

namespace QuizMakerApp.Data
{
    public class QuizMakerAppContext : DbContext
    {
        public QuizMakerAppContext (DbContextOptions<QuizMakerAppContext> options)
            : base(options)
        {
        }

        public DbSet<QuizMakerApp.Models.Quiz> Quiz { get; set; } = default!;
    }
}
