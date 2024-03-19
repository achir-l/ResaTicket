namespace ResaTicket.Model
{
    public class TypeDiffusion
    {
        public int ID { get; set; }

        public String? Nom { get; set; }

        public ICollection<Seance>? Seances { get; set; }
    }
}
