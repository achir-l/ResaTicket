using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Model;

namespace ResaTicket.Pages.TypePaiements
{
    public class DeleteModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public DeleteModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TypePaiement TypePaiement { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typepaiement = await _context.TypePaiement.FirstOrDefaultAsync(m => m.Id == id);

            if (typepaiement == null)
            {
                return NotFound();
            }
            else
            {
                TypePaiement = typepaiement;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typepaiement = await _context.TypePaiement.FindAsync(id);
            if (typepaiement != null)
            {
                TypePaiement = typepaiement;
                _context.TypePaiement.Remove(TypePaiement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
