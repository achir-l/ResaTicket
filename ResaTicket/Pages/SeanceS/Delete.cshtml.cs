using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Model;

namespace ResaTicket.Pages.SeanceS
{
    public class DeleteModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public DeleteModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seance = await _context.Seance
                .Include(c => c.LesTarifs)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (seance != null)
            {
                Seance = seance;
                _context.Seance.Remove(Seance);
                await _context.SaveChangesAsync();
            }

            _context.Tarif.RemoveRange(seance.LesTarifs);


            _context.Seance.Remove(seance);


            return RedirectToPage("./Index");
        }
    }
}
