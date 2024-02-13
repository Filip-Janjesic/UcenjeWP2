using IbanNet;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("E08")]
    public class E08Subota1:ControllerBase
    {
        [HttpGet]
        [Route("zad1")]
        public int Zad1(int PrviBroj, int DrugiBroj)
        {
            // Ruta vraća broj koji je sastavljen od istih brojeva u dva primljena
            // Prvi broj: 248
            // Drugi broj: 942
            // Ruta vraća 24
            string pb = PrviBroj.ToString();
            string db = DrugiBroj.ToString();
            var broj = "";
            foreach(var s in pb)
            {
                foreach (var s1 in db)
                {
                    if (s==s1)
                    {
                        broj += s;
                    } 
                }
            }
            return int.Parse(broj);
           // return Zbroji(PrviBroj,DrugiBroj);
            
        }





        [HttpGet]
        [Route("zad2")]
        public int Zad2(int broj)
        {
            // ruta vraća zbroj prvih broj primljenih brojeva
            return 0;
        
        }

        [HttpGet]
        [Route("zad3")]
        public string Zad3(String s)
        {
            // ruta vraća prvi znak velikim slovom
            // edunova -> E
            return s.Trim()[0].ToString().ToUpper();

        }




    }
}
