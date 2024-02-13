using IbanNet;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("E07")]
    public class E07Metode:ControllerBase
    {
        [HttpGet]
        [Route("zad1")]
        public int Zad1(int PrviBroj, int DrugiBroj)
        {
            // Napišite metodu koja za dva primljena cijela
            // broj vraća njihov zbroj
            // Neka ova metoda Zad1 vrati rezultat napisane metode zadatka
            
            return Zbroji(PrviBroj,DrugiBroj);
            
        }

        [HttpGet]
        [Route("iban")]
        public bool provjeri(string iban)
        {
            return new IbanValidator().Validate(iban).IsValid;
            

        }

        private int Zbroji(int prviBroj, int drugiBroj)
        {
            return prviBroj + drugiBroj;
        }

        // DZ
        // Krierati rutu zad2 koja prima 4 cijela broja
        // i vraća razliku prvi+drugi i treći+četvrti
        // Koristite kreiranu metodu za zbroj dvaju brojeva


        // Krierati rutu zad3 koja prima ime grada i slovo.
        // Ruta vraća broj pojavljivanja slova u primljenom imenu grada
        // Koristiti metode


    }
}
