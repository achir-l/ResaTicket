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
    public class CreateModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;
  
        public Cinema? Cinema { get; set; }
        public CreateModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Seance? Seance { get; set; } = default!;

       
       
        public async Task<IActionResult> OnGetAsync(int? id)
        {
          
            var cinema = await _context.Cinema.FirstOrDefaultAsync(m => m.ID == id);
           // Seance.CinemaID = cinema.ID;

            ViewData["FilmID"] = new SelectList(_context.Film, "ID", "Nom");

            ViewData["TypeDiffusionID"] = new SelectList(_context.TypeDiffusion, "ID", "Nom");

           

            return Page();

        }

    

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int cinemaId = int.Parse(HttpContext.Request.Query["id"]);
            /* if (HttpContext.Request.Query["id"].Count == 0 || !int.TryParse(HttpContext.Request.Query["id"], out int cinemaId))
             {
                 // Gérer le cas où l'ID du cinéma n'est pas fourni
                 // Retourner une erreur ou rediriger vers une page d'erreur par exemple
                 return NotFound();
             }*/

            // Affecter l'ID du cinéma à Seance.CinemaID
            Seance.CinemaID = cinemaId;
            _context.Seance.Add(Seance);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = cinemaId }); 
        }

       

    }
}
