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

namespace ResaTicket.Pages.Cinemas_Paiements
{
    public class DeleteModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public DeleteModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cinema_Paiement Cinema_Paiement { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinema_paiement = await _context.CinemaPaiement.FirstOrDefaultAsync(m => m.ID == id);

            if (cinema_paiement == null)
            {
                return NotFound();
            }
            else
            {
                Cinema_Paiement = cinema_paiement;
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
                .FirstOrDefaultAsync(m => m.ID == id);

            if (cinema == null)
            {
                return NotFound();
            }

         

         
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }



    }
}
