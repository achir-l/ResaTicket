using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Model;

namespace ResaTicket.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Cinema>? Cinema { get; set; }

        public DbSet<Seance>? Seance { get; set; }

        public DbSet<Film>? Film { get; set; }

        public DbSet<Film_Langue>? Film_Langue { get; set; }

        public DbSet<Langue>? Langue { get; set; }

        public DbSet<TypeDiffusion> TypeDiffusion { get; set; }

        public DbSet<Tarif> Tarif { get; set; }

        public DbSet<TypePaiement> TypePaiement { get; set; }

        public DbSet<Cinema_Paiement> CinemaPaiement { get; set; }




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
