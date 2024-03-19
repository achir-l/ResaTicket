using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Data.Migrations;
using ResaTicket.Model;

namespace ResaTicket.Pages.Films
{
    public class DeleteModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public DeleteModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Film Film { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film.FirstOrDefaultAsync(m => m.ID == id);

            if (film == null)
            {
                return NotFound();
            }
            else
            {
                Film = film;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var film = await _context.Film
                .Include(c => c.LesFilmsLangue)
                .FirstOrDefaultAsync(m => m.ID == id);
            
            if (film != null)
            {
                Film = film;
                _context.Film.Remove(Film);
                await _context.SaveChangesAsync();
            }

            _context.Film_Langue.RemoveRange(film.LesFilmsLangue);


            _context.Film.Remove(film);

            return RedirectToPage("./Index");
        }
    }
}
