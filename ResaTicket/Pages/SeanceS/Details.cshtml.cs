using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Model;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ResaTicket.Pages.SeanceS
{
    public class DetailsModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public DetailsModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Seance Seance { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seance = await _context.Seance.FirstOrDefaultAsync(m => m.ID == id);
            if (seance == null)
            {
                return NotFound();
            }
            else
            {
                Seance = seance;
            }
            ViewData["FilmID"] = new SelectList(_context.Film, "ID", "Nom");
            ViewData["TypeDiffusionID"] = new SelectList(_context.Film, "ID", "Nom");
            return Page();
        }
    }
}

