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



namespace ResaTicket.Pages.SeanceS
{
    public class EditModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public EditModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Seance Seance { get; set; } = default!;

        /*public async Task<IActionResult> OnGetAsync(int? id)
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
             Seance = seance;
             ViewData["FilmID"] = new SelectList(_context.Film, "ID", "Nom");
             ViewData["TypeDiffusionID"] = new SelectList(_context.TypeDiffusion, "ID", "Nom");
             return Page();
         }*/

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seance = await _context.Seance.FirstOrDefaultAsync(m => m.ID == id);

            if (Seance == null)
            {
                return NotFound();
            }

            return Page();
        }





        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        // Méthode pour gérer la soumission du formulaire
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Seance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeanceExists(Seance.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            
            return RedirectToPage("./Index", new { id = Seance.CinemaID });
        }


        private bool SeanceExists(int id)
        {
            return _context.Seance.Any(e => e.ID == id);
        }
    }
}

