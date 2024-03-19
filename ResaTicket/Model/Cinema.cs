using System.ComponentModel.DataAnnotations;

namespace ResaTicket.Model
{
    public class Cinema
    {
        public int ID { get; set; }
        public String? Nom { get; set; }
        public String? Num_rue { get; set; }
        public String? Rue { get; set; }
        public String? Code_Postal { get; set; }
        public String? Ville { get; set; }
        public String? Comp_Adresse { get; set; }
        public String? SIRET { get; set; }
        public String? RIB { get; set; }
        public int? Statut { get; set; }

        public ICollection<Cinema_Paiement>? LesCinemaPaiement { get; set; }

        public ICollection<Seance>? Seances { get; set; }

        [Display(Name = "Tarif de la séance")]
        public ICollection<Tarif>? LesTarifs { get; set; }

    }
}
