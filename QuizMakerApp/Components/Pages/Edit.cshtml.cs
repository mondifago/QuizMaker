using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuizMakerApp.Data;
using QuizMakerApp.Models;

namespace QuizMakerApp.Components.Pages
{
    public class EditModel : PageModel
    {
        private readonly QuizMakerApp.Data.QuizMakerAppContext _context;

        public EditModel(QuizMakerApp.Data.QuizMakerAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Quiz Quiz { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz =  await _context.Quiz.FirstOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }
            Quiz = quiz;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Quiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(Quiz.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool QuizExists(Guid id)
        {
            return _context.Quiz.Any(e => e.Id == id);
        }
    }
}
