namespace ResaTicket.Model
{
    public class Tarif
    {
        public int Id { get; set; }

        public string? TypeTarif { get; set; }

        public int? prix { get; set; }
        //Lien de composition vers La seance
        public int? SEANCEID { get; set; }
        public Seance? NSEANCE { get; set; }


        //Lien de composition vers Le cinéma
        public int? CINEMAID { get; set; }
        public Cinema? NCINEMA { get; set; }
    }
}
