using EdunovaAPP.Data;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EdunovaAPP.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class SmjerController : EdunovaController<Smjer,SmjerDTORead,SmjerDTOInsertUpdate>
    {
        public SmjerController(EdunovaContext context) : base(context)
        {
            DbSet=_context.Smjerovi;
        }



        [HttpGet]
        [Route("Oznake/{sifraSmjera:int}")]
        public IActionResult GetOznake(int sifraSmjera)
        {
            // kontrola ukoliko upit nije valjan
            if (!ModelState.IsValid || sifraSmjera <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var oznake = _context.SmjeroviOznake
                    .Include(i => i.Oznaka)
                    .Include(i => i.Smjer)
                    .Where(x => x.Smjer.Sifra == sifraSmjera).ToList();
                if (oznake == null)
                {
                    return BadRequest("Ne postoje oznake s šifrom " + sifraSmjera + " u bazi");
                }

                // nisam radio posebno mapper
                List<SmjerOznakaDTORead> lista = new List<SmjerOznakaDTORead>();
                oznake.ForEach(x => lista.Add(new SmjerOznakaDTORead(x.Sifra,x.Oznaka.Naziv,x.napomena)));
          
                return new JsonResult(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPost]
        [Route("DodajOznaku")]
        public IActionResult DodajOznaku(SmjerOznakaDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var smjer = _context.Smjerovi.Find(dto.smjerSifra);

                if (smjer == null)
                {
                    throw new Exception("Ne postoji smjer s šifrom " + dto.smjerSifra + " u bazi");
                }

                var oznaka = _context.Oznake.Find(dto.oznakaSifra);

                if (oznaka == null)
                {
                    throw new Exception("Ne postoji oznaka s šifrom " + dto.oznakaSifra + " u bazi");
                }

                var entitet = new SmjerOznaka() { Smjer = smjer, Oznaka = oznaka, napomena = dto.napomena };

                _context.SmjeroviOznake.Add(entitet);
                _context.SaveChanges();

                return new JsonResult(new SmjerOznakaDTORead(entitet.Sifra,entitet.Oznaka.Naziv,entitet.napomena));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpDelete]
        [Route("ObrisiOznaku/{sifra:int}")]
        public IActionResult ObrisiOznaku(int sifra)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (sifra <= 0 )
            {
                return BadRequest("Šifra oznake nije dobra");
            }

            try
            {

                var entitet = _context.SmjeroviOznake.Find(sifra);

                if (entitet == null)
                {
                    return BadRequest("Ne postoji oznaka na smjeru s šifrom " + sifra + " u bazi");
                }

                _context.SmjeroviOznake.Remove(entitet);
                _context.SaveChanges();

                return Ok("Obrisano");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPatch]
        [Route("PromjeniOznaku/{sifra:int}")]
        public IActionResult PromjeniOznaku(int sifra, string napomena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var entitet = _context.SmjeroviOznake.Include(x=>x.Oznaka).FirstOrDefault(x=>x.Sifra==sifra);

                if(entitet==null)
                {
                    return BadRequest("Ne postoji oznaka na na smjeru s šifrom " + sifra + " u bazi");
                }       

                entitet.napomena = napomena;

                _context.SmjeroviOznake.Update(entitet);
                _context.SaveChanges();

                return new JsonResult(new SmjerOznakaDTORead(entitet.Sifra, entitet.Oznaka.Naziv, entitet.napomena));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        protected override void KontrolaBrisanje(Smjer entitet)
        {
            var lista = _context.Grupe.Include(x => x.Smjer).Where(x => x.Smjer.Sifra == entitet.Sifra).ToList();

            if (lista != null && lista.Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Smjer se ne može obrisati jer je postavljen na grupama: ");
                foreach (var e in lista)
                {
                    sb.Append(e.Naziv).Append(", ");
                }

                throw new Exception(sb.ToString().Substring(0, sb.ToString().Length - 2));
            }
        }
       
    }
}
