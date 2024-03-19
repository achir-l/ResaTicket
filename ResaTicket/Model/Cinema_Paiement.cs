namespace ResaTicket.Model
{
    public class Cinema_Paiement
    {
        public int? ID { get; set; }


        public int? CinemaID { get; set; }
        public Cinema? TCinema { get; set; }

        public int? TypePaiementID { get; set; }
        public TypePaiement? TTypePaiement { get; set; }
        }
}
