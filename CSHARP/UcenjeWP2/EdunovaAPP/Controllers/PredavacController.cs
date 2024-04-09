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
    public class PredavacController : EdunovaController<Predavac, PredavacDTORead, PredavacDTOInsertUpdate>
    {
        public PredavacController(EdunovaContext context) : base(context)
        {
            DbSet = _context.Predavaci;
            _mapper = new MappingPredavac();
        }

        protected override void KontrolaBrisanje(Predavac entitet)
        {
            var lista = _context.Grupe.Include(x => x.Predavac).Where(x => x.Predavac.Sifra == entitet.Sifra).ToList();

            if (lista != null && lista.Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Predavač se ne može obrisati jer je postavljen na grupama: ");
                foreach (var e in lista)
                {
                    sb.Append(e.Naziv).Append(", ");
                }

                throw new Exception(sb.ToString().Substring(0, sb.ToString().Length - 2));
            }
        }

        [HttpPatch]
        [Route("{sifraPredavac:int}")]
        public async Task<ActionResult> Patch(int sifraPredavac, IFormFile datoteka)
        {
            if (datoteka == null)
            {
                return BadRequest("Datoteka nije postavljena");
            }

            var entitetIzbaze = _context.Predavaci.Find(sifraPredavac);

            if (entitetIzbaze == null)
            {
                return BadRequest("Ne postoji predavač s šifrom " + sifraPredavac + " u bazi");
            }
            try
            {
                var ds = Path.DirectorySeparatorChar;
                string dir = Path.Combine(Directory.GetCurrentDirectory()
                    + ds + "wwwroot" + ds + "datoteke" + ds + "predavaci");
                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                var putanja = Path.Combine(dir + ds + sifraPredavac + "_" + System.IO.Path.GetExtension(datoteka.FileName));
                Stream fileStream = new FileStream(putanja, FileMode.Create);
                await datoteka.CopyToAsync(fileStream);
                return Ok("Datoteka pohranjena");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
