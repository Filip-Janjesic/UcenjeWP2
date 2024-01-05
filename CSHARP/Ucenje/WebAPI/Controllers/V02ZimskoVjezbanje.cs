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
        public IActionResult Vjezba3()
        {
            int zbroj = 0;

            for (int i = 2; i <= 18; i += 2)
            {
                zbroj += i;
            }

            return Ok(zbroj);
        }

        // 4. Ruta prima jedan parametar koji je cijli broj i vraća zbroj svih brojava od 1 do primljenog broja
        [HttpGet]
        [Route("vjezba4")]
        public IActionResult Vjezba4(int broj)
        {
            int zbroj = 0;

            for (int i = 1; i <= broj; i++)
            {
                zbroj += i;
            }

            return Ok(zbroj);
        }

        // 5. Ruta prima dva parametra koji su cijeli brojevi i vraća niz s svim parnim brojevima između primljenih brojeva
        [HttpGet]
        [Route("vjezba5")]
        public IActionResult Vjezba5(int broj1, int broj2)
        {
            if (broj1 > broj2)
            {
                int temp = broj1;
                broj1 = broj2;
                broj2 = temp;
            }

            int[] parniBrojevi = Enumerable.Range(broj1, broj2 - broj1 + 1)
                                           .Where(x => x % 2 == 0)
                                           .ToArray();

            return Ok(parniBrojevi);
        }

        // 6. Ruta prima dva parametra koji su cijeli brojevi i vraća niz s svim neparnim brojevima između primljenih brojeva
        [HttpGet]
        [Route("vjezba6")]
        public IActionResult Vjezba6(int broj1, int broj2)
        {
            if (broj1 > broj2)
            {
                int temp = broj1;
                broj1 = broj2;
                broj2 = temp;
            }

            int[] neparniBrojevi = Enumerable.Range(broj1, broj2 - broj1 + 1)
                                             .Where(x => x % 2 != 0)
                                             .ToArray();

            return Ok(neparniBrojevi);
        }

        // 7. Ruta prima dva parametra koji su cijeli brojevi i vraća zbroj svih brojeva između primljenih brojeva
        [HttpGet]
        [Route("vjezba7")]
        public IActionResult Vjezba7(int broj1, int broj2)
        {
            if (broj1 > broj2)
            {
                int temp = broj1;
                broj1 = broj2;
                broj2 = temp;
            }

            int zbroj = Enumerable.Range(broj1, broj2 - broj1 + 1)
                                  .Sum();

            return Ok(zbroj);
        }

        // 8. Ruta prima dva parametra koji su cijeli brojevi i vraća zbroj svih brojeva između primljenih brojeva koji su cjelobrojno djeljivi s 3
        [HttpGet]
        [Route("vjezba8")]
        public IActionResult Vjezba8(int broj1, int broj2)
        {
            if (broj1 > broj2)
            {
                int temp = broj1;
                broj1 = broj2;
                broj2 = temp;
            }

            int zbrojDjeljiviSa3 = Enumerable.Range(broj1, broj2 - broj1 + 1)
                                             .Where(x => x % 3 == 0)
                                             .Sum();

            return Ok(zbrojDjeljiviSa3);
        }

        // 9. Ruta prima dva parametra koji su cijeli brojevi i vraća zbroj svih brojeva između primljenih brojeva koji su cjelobrojno djeljivi s 3 i 5
        [HttpGet]
        [Route("vjezba9")]
        public IActionResult Vjezba9(int broj1, int broj2)
        {
            if (broj1 > broj2)
            {
                int temp = broj1;
                broj1 = broj2;
                broj2 = temp;
            }

            int zbrojDjeljiviSa3i5 = Enumerable.Range(broj1, broj2 - broj1 + 1)
                                               .Where(x => x % 3 == 0 && x % 5 == 0)
                                               .Sum();

            return Ok(zbrojDjeljiviSa3i5);
        }

        // 10. Ruta prima dva parametra koji su cijeli brojevi i vraća dvodimenzionalni niz (matricu) koja sadrži tablicu množenja za dva primljena broja
        [HttpGet]
        [Route("vjezba10")]
        public IActionResult Vjezba10(int broj1, int broj2)
        {
            int[][] matrica = new int[10][];

            for (int i = 0; i < 10; i++)
            {
                matrica[i] = new int[10];

                for (int j = 0; j < 10; j++)
                {
                    matrica[i][j] = (i + 1) * (j + 1);
                }
            }

            return Ok(matrica);
        }

        // 11. Ruta prima jedan parametar koji je cijeli broj i vraća niz cijelih brojeva koji su složeni od primljenog broja do broja 1
        [HttpGet]
        [Route("vjezba11")]
        public IActionResult Vjezba11(int broj)
        {
            if (broj < 1)
            {
                return BadRequest("Broj mora biti jednak ili veći od 1.");
            }

            List<int> rezultat = new List<int>();

            while (broj > 0)
            {
                rezultat.Add(broj);
                broj--;
            }

            return Ok(rezultat.ToArray());
        }

        // 12. Ruta prima cijeli broj i vraća logičku istinu ako je primljeni broj prosti (prim - prime) broj, odnosno logičku laž ako nije
        [HttpGet]
        [Route("vjezba12")]
        public IActionResult Vjezba12(int broj)
        {
            if (broj < 2)
            {
                return Ok(false);
            }

            for (int i = 2; i <= Math.Sqrt(broj); i++)
            {
                if (broj % i == 0)
                {
                    return Ok(false);
                }
            }

            return Ok(true);
        }

        // 13. Ruta prima dva parametra koji su cijeli brojevi te vraća dvodimenzionalni niz (matricu) cijelih brojeva koji su složeni prema slici zadatka: Ciklična matrica
    }
}
