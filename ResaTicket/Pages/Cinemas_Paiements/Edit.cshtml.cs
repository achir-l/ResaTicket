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

namespace ResaTicket.Pages.Cinemas_Paiements
{
    public class EditModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public EditModel(ResaTicket.Data.ApplicationDbContext context)
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
            Cinema_Paiement = cinema_paiement;

            ViewData["CinemaID"] = new SelectList(_context.Cinema, "ID", "ID");
            ViewData["TypePaiementID"] = new SelectList(_context.TypePaiement, "Id", "Nom");

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

            _context.Attach(Cinema_Paiement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cinema_PaiementExists(Cinema_Paiement.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { id = Cinema_Paiement.CinemaID });
        }

        private bool Cinema_PaiementExists(int? id)
        {
            return _context.CinemaPaiement.Any(e => e.ID == id);
        }
    }
}
