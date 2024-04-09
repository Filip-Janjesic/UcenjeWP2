using EdunovaAPP.Data;
using EdunovaAPP.Mappers;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EdunovaAPP.Controllers
{
   
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PolaznikController : EdunovaController<Polaznik, PolaznikDTORead, PolaznikDTOInsertUpdate>
    {
        public PolaznikController(EdunovaContext context) : base(context)
        {
            DbSet = _context.Polaznici;
            _mapper = new MappingPolaznik();
        }

        [HttpGet]
        [Route("trazi/{uvjet}")]
        public IActionResult TraziPolaznik(string uvjet)
        {
            // ovdje će ići dohvaćanje u bazi

            if (uvjet == null || uvjet.Length < 3)
            {
                return BadRequest(ModelState);
            }

            // ivan se PROBLEM riješiti višestruke uvjete
            uvjet = uvjet.ToLower();
            try
            {
                IEnumerable<Polaznik> query = _context.Polaznici;
                var niz = uvjet.Split(" ");

                foreach (var s in uvjet.Split(" "))
                {
                    query = query.Where(p => p.Ime.ToLower().Contains(s) || p.Prezime.ToLower().Contains(s));
                }


                var polaznici = query.ToList();

                return new JsonResult(_mapper.MapReadList(polaznici)); 

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("postaviSliku/{sifra:int}")]
        public IActionResult PostaviSliku(int sifra, SlikaDTO slika)
        {
            if (sifra <= 0)
            {
                return BadRequest("Šifra mora biti veća od nula (0)");
            }
            if (slika.Base64 == null || slika.Base64?.Length == 0)
            {
                return BadRequest("Slika nije postavljena");
            }
            var p = _context.Polaznici.Find(sifra);
            if (p == null)
            {
                return BadRequest("Ne postoji polaznik s šifrom " + sifra + ".");
            }
            try
            {
                var ds = Path.DirectorySeparatorChar;
                string dir = Path.Combine(Directory.GetCurrentDirectory()
                    + ds + "wwwroot" + ds + "slike" + ds + "polaznici");

                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                var putanja = Path.Combine(dir + ds + sifra + ".png");
                System.IO.File.WriteAllBytes(putanja, Convert.FromBase64String(slika.Base64));
                return Ok("Uspješno pohranjena slika");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("traziStranicenje/{stranica}")]
        public IActionResult TraziPolaznikStranicenje(int stranica, string uvjet = "")
        {
            var poStranici = 8;
            uvjet = uvjet.ToLower();
            try
            {
                var polaznici = _context.Polaznici
                    .Where(p => EF.Functions.Like(p.Ime.ToLower(), "%" + uvjet + "%")
                                || EF.Functions.Like(p.Prezime.ToLower(), "%" + uvjet + "%"))
                    .Skip((poStranici * stranica) - poStranici)
                    .Take(poStranici)
                    .OrderBy(p => p.Prezime)
                    .ToList();


                return new JsonResult(_mapper.MapReadList(polaznici));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        protected override void KontrolaBrisanje(Polaznik entitet)
        {
            var entitetIzbaze = _context.Polaznici.Include(x => x.Grupe).FirstOrDefault(x => x.Sifra == entitet.Sifra);

            if (entitetIzbaze == null)
            {
                throw new Exception("Ne postoji polaznik s šifrom " + entitet.Sifra + " u bazi");
            }


            if (entitetIzbaze.Grupe != null && entitetIzbaze.Grupe.Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Polaznik se ne može obrisati jer je postavljen na grupama: ");
                foreach (var e in entitetIzbaze.Grupe)
                {
                    sb.Append(e.Naziv).Append(", ");
                }

                throw new Exception(sb.ToString().Substring(0, sb.ToString().Length - 2));
            }
        }

    }
}
