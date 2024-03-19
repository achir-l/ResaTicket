using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Model;


namespace ResaTicket.Pages.FilmsLangues
{
    public class EditModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public EditModel(ResaTicket.Data.ApplicationDbContext context)
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
            Film_Langue = film_langue;
            ViewData["FilmID"] = new SelectList(_context.Film, "ID", "Nom");
            ViewData["LangueID"] = new SelectList(_context.Langue, "ID", "Nom");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Film_Langue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Film_LangueExists(Film_Langue.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { id = Film_Langue.FilmID });
        }

        private bool Film_LangueExists(int? id)
        {
            return _context.Film_Langue.Any(e => e.ID == id);
        }
    }
}

