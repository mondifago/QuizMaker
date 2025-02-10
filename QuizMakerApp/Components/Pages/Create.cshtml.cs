using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizMakerApp.Data;
using QuizMakerApp.Models;

namespace QuizMakerApp.Components.Pages
{
    public class CreateModel : PageModel
    {
        private readonly QuizMakerApp.Data.QuizMakerAppContext _context;

        public CreateModel(QuizMakerApp.Data.QuizMakerAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Quiz Quiz { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Quiz.Add(Quiz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
