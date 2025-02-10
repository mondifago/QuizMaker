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
    public class DetailsModel : PageModel
    {
        private readonly QuizMakerApp.Data.QuizMakerAppContext _context;

        public DetailsModel(QuizMakerApp.Data.QuizMakerAppContext context)
        {
            _context = context;
        }

        public Quiz Quiz { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz.FirstOrDefaultAsync(m => m.Id == id);

            if (quiz is not null)
            {
                Quiz = quiz;

                return Page();
            }

            return NotFound();
        }
    }
}
