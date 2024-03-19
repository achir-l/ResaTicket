
using System.ComponentModel.DataAnnotations;

namespace ResaTicket.Model
{
    public class Seance
    {
        public int ID { get; set; }
        public String? Horaire { get; set; }

        public string? Statut { get; set; }

        public string? NumeroSalle { get; set; }

        [Display(Name = "Date du jour")]
        [DataType(DataType.Date)]
        public DateTime DateJour { get; set; }

        public int? FilmID { get; set; }

        public Film? Film { get; set; }

        public int? TypeDiffusionID { get; set; }

        public TypeDiffusion? TypeDiffusion { get; set; }

        public int? CinemaID { get; set; }

        public Cinema? Cinema { get; set; }

        [Display(Name = "Tarif de la séance")] 
        public ICollection<Tarif>? LesTarifs { get; set; }
    }

}
