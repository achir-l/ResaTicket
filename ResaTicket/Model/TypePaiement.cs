namespace ResaTicket.Model
{
    public class TypePaiement
    {
        public int Id { get; set; }

        public string Nom { get; set; }


        public ICollection<Cinema_Paiement>? LesCinemaPaiement{ get; set; }


    }
}
