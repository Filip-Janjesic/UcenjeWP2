using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("E02")]
    public class E02VarijableTipoviPodatakaOperatori:ControllerBase
    {
        [HttpGet]
        [Route("zad1")]
        public int Zad1()
        {
            // vratite najmanji broj
            return int.MinValue;
        }

        [HttpGet]
        [Route("zad2")]
        public float Zad2(int i, int j)
        {
            // Ruta vraća kvocijent dvaju primljenih brojeva
            return 0; // Ovo ne valja, DZ
        }

        [HttpGet]
        [Route("zad3")]
        public float Zad3(int i, int j)
        {
            // Ruta vraća zbroj umnoška i kvocijenta primljenih brojeva
            var umnozak = i * j; // var je ključna riječ koja preuzima tip podatka s desne strane znaka =
            var kvocijent = (float)i / j;
            return umnozak + kvocijent;
        }

        [HttpGet]
        [Route("zad4")]
        public string Zad4(string s, string s1)
        {
            // Ruta vraća spojene primljene znakove
            return s + s1;
        }

        [HttpGet]
        [Route("zad5")]
        public bool IstiSu(int a, int b)
        {
            Console.WriteLine("a={0}",a); // pogledati u konzoli
            // ruta vraća true ako je a jednako b, inače vraća false
            return a == b;
        }
    }
}
