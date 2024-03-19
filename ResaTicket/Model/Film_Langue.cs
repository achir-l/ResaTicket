

namespace ResaTicket.Model
{
    public class Film_Langue
    {
        public int? ID { get; set; }

        public int? FilmID { get; set; }
        public Film? LFilm { get; set; }

        public int? LangueID { get; set; }
        public Langue? LLangue { get; set; }
    }
}
