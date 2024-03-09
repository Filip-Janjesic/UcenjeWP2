namespace EdunovaAPP.Models
{
    public class Polaznik: Osoba
    {
        public string? BrojUgovora { get; set; }

        public ICollection<Grupa>? Grupe { get; } = new List<Grupa>();
    }
}
