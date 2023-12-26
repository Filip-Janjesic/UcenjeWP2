using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("VO1")]
    public class V01 : Controller
    {
        [HttpGet]
        [Route("vjezba1")]
        public IActionResult Vjezba1(int broj1, int broj2, string operacija)
        {
            double rezultat = 0;

            switch (operacija)
            {
                case "+":
                    rezultat = broj1 + broj2;
                    break;
                case "-":
                    rezultat = broj1 - broj2;
                    break;
                case "*":
                    rezultat = broj1 * broj2;
                    break;
                case "/":
                    if (broj2 != 0)
                    {
                        rezultat = (double)broj1 / broj2;
                    }
                    else
                    {
                        return BadRequest("Dijeljenje s nulom nije dozvoljeno.");
                    }
                    break;
                default:
                    return BadRequest("Nepodržana operacija.");
            }

            return Ok(rezultat);
        }

        [HttpPost]
        [Route("vjezba2")]
        public IActionResult Vjezba2([FromBody] decimal[] brojevi)
        {
            if (brojevi == null || brojevi.Length == 0)
            {
                return BadRequest("Niz brojeva je prazan.");
            }

            decimal prviElement = brojevi[0];
            decimal zadnjiElement = brojevi[brojevi.Length - 1];

            int cijeliDioPrvogElementa = (int)prviElement;
            decimal decimalniDioZadnjegElementa = zadnjiElement - Math.Floor(zadnjiElement);

            decimal rezultat = cijeliDioPrvogElementa + decimalniDioZadnjegElementa;

            return Ok(rezultat);
        }
    }
}





