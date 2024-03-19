using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Model;
using System.Threading.Tasks;

namespace ResaTicket.Pages.Cinemas_Paiements
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Cinema? Cinema { get; set; }
        public CreateModel(ApplicationDbContext context)
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

            // Maintenant, vous pouvez utiliser id en toute sécurité car vous avez vérifié s'il avait une valeur
            Cinema = await _context.Cinema.FirstOrDefaultAsync(m => m.ID == id);

            ViewData["TypePaiementID"] = new SelectList(_context.TypePaiement, "Id", "Nom");
            return Page();
        }


        /* public async Task<IActionResult> OnPostAsync()
         {
             if (!ModelState.IsValid)
             {
                 return Page();

             }


             _context.CinemaPaiement.Add(Cinema_Paiement);
             await _context.SaveChangesAsync();

             return RedirectToPage("../Cinemas_Paiements/Index" );
         }
     }*/
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Vérifiez si le type de paiement correspondant à l'ID existe dans la base de données
            var typePaiement = await _context.TypePaiement.FindAsync(Cinema_Paiement.TypePaiementID);
            if (typePaiement == null)
            {
                // Si le type de paiement n'existe pas, renvoyez une erreur
                ModelState.AddModelError(string.Empty, "Le type de paiement spécifié n'existe pas.");
                return Page();
            }

            // Si le type de paiement existe, ajoutez le cinema paiement à la base de données
            _context.CinemaPaiement.Add(Cinema_Paiement);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Cinemas_Paiements/Index", new { id = Cinema_Paiement.CinemaID });
        }

    }
}
