using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizMakerApp.Data;
using QuizMakerApp.Models;

namespace QuizMakerApp.Components.Pages
{
    public class IndexModel : PageModel
    {
        private readonly QuizMakerApp.Data.QuizMakerAppContext _context;

        public IndexModel(QuizMakerApp.Data.QuizMakerAppContext context)
        {
            _context = context;
        }

        public IList<Quiz> Quiz { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Quiz = await _context.Quiz.ToListAsync();
        }
    }
}
