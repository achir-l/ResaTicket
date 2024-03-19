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
    public class CreateModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;
        public Film? Film { get; set; }

        public CreateModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        /*public IActionResult OnGet()
        {
        ViewData["FilmID"] = new SelectList(_context.Film, "ID", "ID");
        ViewData["LangueID"] = new SelectList(_context.Langue, "ID", "ID");
            return Page();
        }*/
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Film = await _context.Film.FirstOrDefaultAsync(m => m.ID == (int)id);
            ViewData["LangueID"] = new SelectList(_context.Langue, "ID", "Nom");
            return Page();
        }

        [BindProperty]
        public Film_Langue Film_Langue { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Film_Langue.Add(Film_Langue);
            await _context.SaveChangesAsync();

            return RedirectToPage("../FilmsLangues/Index", new { id = Film_Langue.FilmID });
        }


    }
}
