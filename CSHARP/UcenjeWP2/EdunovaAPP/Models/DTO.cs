namespace EdunovaAPP.Models
{
    public record SmjerDTORead(int sifra, string naziv, int trajanje,
        decimal cijena, decimal upisnina, bool verificiran);

    public record SmjerDTOInsertUpdate(string naziv, int trajanje,
        decimal cijena, decimal upisnina, bool verificiran);


}
