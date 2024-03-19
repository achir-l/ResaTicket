

namespace ResaTicket.Model
{
    public class Film
    {
        public int ID { get; set; }
        public String? Nom { get; set; }

        public String? Duree { get; set; }

        public String? Description { get; set; }

        public String? Realisateur { get; set; }

        public String? Acteur { get; set; }

        public String? Image { get; set; }

        public int? LangueID { get; set; }
        public Langue? Langue { get; set; }

        public ICollection<Seance>? Seances { get; set; }

        public ICollection<Film_Langue>? LesFilmsLangue { get; set; }

    }
}
