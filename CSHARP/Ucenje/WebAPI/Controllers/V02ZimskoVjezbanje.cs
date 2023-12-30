using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("VO2")]

    public class V02ZimskoVjezbanje : ControllerBase
    {
        // 1. Ruta ne prima niti jedan parametar i vraća zbroj prvih 100 brojeva
        [HttpGet]
        [Route("vjezba1")]
        public IActionResult Vjezba1()
        {
            int zbroj = Enumerable.Range(1, 100).Sum();
            return Ok($"Zbroj prvih 100 brojeva je: {zbroj}");
        }

        // 2. Ruta ne prima niti jedan parametar i vraća niz s svim parnim brojevima od 1 do 57
        [HttpGet]
        [Route("vjezba2")]
        public IActionResult Vjezba2() 
        {
            var parniBrojevi = new System.Collections.Generic.List<int>();
            for (int i = 1; i <= 57; i += 2)
            {
                parniBrojevi.Add(i);
            }
            return Ok(parniBrojevi);
        }

        // 3. Ruta ne prima niti jedan parametar i vraća zbroj svih parnih brojeva od 2 do 18
        [HttpGet]
        [Route("vjezba3")]
        public IActionResult ZbrojParnihBrojeva()
        {
            int zbroj = 0;

            for (int i = 2; i <= 18; i += 2)
            {
                zbroj += i;
            }

            return Ok(zbroj);
        }

    }

}
