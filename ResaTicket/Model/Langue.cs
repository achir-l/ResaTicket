namespace ResaTicket.Model
{
    public class Langue
    {
        public int ID { get; set; }

        public string? CodeLangue { get; set; }
        public String? Nom { get; set; }

        // public ICollection<Film>? LangueF { get; set; }

        public ICollection<Film_Langue>? LesFilmsLangue { get; set; }
    }
}
