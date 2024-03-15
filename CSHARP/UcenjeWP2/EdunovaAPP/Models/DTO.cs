using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;

namespace EdunovaAPP.Models
{
    public record SmjerDTORead(int sifra, string naziv, int trajanje,
        decimal cijena, decimal upisnina, bool verificiran);

    public record SmjerDTOInsertUpdate(string naziv, int trajanje,
        decimal cijena, decimal upisnina, bool verificiran);






    public record PolaznikDTORead(int sifra, string ime, string prezime,
        string email, string oib, string brojugovora);

    public record PolaznikDTOInsertUpdate( string ime, string prezime,
        string email, string oib, string brojugovora);




    public record PredavacDTORead(int sifra, string ime, string prezime,
        string email, string oib, string iban);

    public record PredavacDTOInsertUpdate(string ime, string prezime,
        string email, string oib, string iban);

    
   
    public record GrupaDTORead( int sifra, string? naziv,
        string? smjerNaziv , string? predavacImePrezime ,  int brojpolaznika , DateTime? datumpocetka, int? maksimalnopolaznika);
    // ako se parametar zove kao svojstvo nekog tipa u toj klasi tada uzima punu putanju klase (npr. EdunovaAPP.Models.Predavac)



    public record GrupaDTOInsertUpdate( string? naziv, 
        int? smjerSifra, int? predavacSifra, DateTime? datumpocetka, int? maksimalnopolaznika= 0);

}
