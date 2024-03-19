using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Model;



namespace ResaTicket.Pages.FilmsLangues
{
    public class DeleteModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public DeleteModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Film_Langue Film_Langue { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film_langue = await _context.Film_Langue.FirstOrDefaultAsync(m => m.ID == id);

            if (film_langue == null)
            {
                return NotFound();
            }
            else
            {
                Film_Langue = film_langue;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film_langue = await _context.Film_Langue.FindAsync(id);
            if (film_langue != null)
            {
                Film_Langue = film_langue;
                _context.Film_Langue.Remove(Film_Langue);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id = Film_Langue.FilmID });
        }
    }
}

