using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Model;



namespace ResaTicket.Pages.Cinemas
{
    public class DeleteModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public DeleteModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cinema Cinema { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinema = await _context.Cinema.FirstOrDefaultAsync(m => m.ID == id);

            if (cinema == null)
            {
                return NotFound();
            }
            else
            {
                Cinema = cinema;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinema = await _context.Cinema
                .Include(c => c.LesCinemaPaiement)
                .Include(c => c.LesTarifs)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (cinema == null)
            {
                return NotFound();
            }

            
            _context.CinemaPaiement.RemoveRange(cinema.LesCinemaPaiement);
            _context.Tarif.RemoveRange(cinema.LesTarifs);


            _context.Cinema.Remove(cinema);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}

