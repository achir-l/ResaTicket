using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ResaTicket.Pages.Tarifs
{
    public class EditModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public EditModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tarif? Tarif { get; set; }


        [BindProperty]
        public Cinema? Cinema { get; set; }

        public Seance? Seance { get; set; }

        public List<Seance>? Seances { get; set; } = new List<Seance>();

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["CINEMAID"] = new SelectList(_context.Cinema, "ID", "Nom");
            return Page();
        }

        public async Task<IActionResult> OnPostChargerUEAsync()
        {
            if (Tarif?.CINEMAID == null)
            {
                ModelState.AddModelError(string.Empty, "Veuillez sélectionner un cinéma.");
                return Page();
            }

            Cinema = await _context.Cinema
                .Include(c => c.Seances)
                .FirstOrDefaultAsync(c => c.ID == Tarif.CINEMAID);

            if (Cinema == null)
            {
                return NotFound();
            }

            Seances = Cinema.Seances.ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostGarderTarifsAsync(Dictionary<int, Tarif> tarifs)
        {
           
            foreach (var (seanceID, tarif) in tarifs)
            {
                Console.WriteLine($"Seance ID: {seanceID}, TypeTarif: {tarif.TypeTarif}, Prix: {tarif.prix}, CinemaID: {tarif.CINEMAID}");

                // Créez une nouvelle instance de Tarif avec les valeurs récupérées
                Tarif newTarif = new Tarif
                {
                    TypeTarif = tarif.TypeTarif,
                    prix = tarif.prix,
                    SEANCEID = tarif.SEANCEID,
                    CINEMAID = Tarif.CINEMAID // Utilisez l'ID du cinéma associé au formulaire actuel
                };

                // Ajoutez le nouvel objet Tarif à votre contexte de base de données
                _context.Tarif.Add(newTarif);
            }

            // Enregistrez les modifications dans la base de données
            await _context.SaveChangesAsync();

            return RedirectToPage("../Cinemas/Index");
        }


    }
}
