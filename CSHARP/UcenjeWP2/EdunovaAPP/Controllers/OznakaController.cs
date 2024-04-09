using EdunovaAPP.Data;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EdunovaAPP.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class OznakaController : EdunovaController<Oznaka, OznakaDTORead, OznakaDTOInsertUpdate>
    {
        public OznakaController(EdunovaContext context) : base(context)
        {
            DbSet=_context.Oznake;
        }

        [HttpGet]
        [Route("trazi/{uvjet}")]
        public IActionResult TraziOznaka(string uvjet)
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
                var oznake = _context.Oznake.Where(p => p.Naziv.ToLower().Contains(uvjet)).ToList();

                return new JsonResult(_mapper.MapReadList(oznake)); //200

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        protected override void KontrolaBrisanje(Oznaka entitet)
        {
            var lista = _context.SmjeroviOznake
                .Include(x => x.Oznaka)
                .Include(x => x.Smjer)
                .Where(x => x.Oznaka.Sifra == entitet.Sifra).ToList();

            if (lista != null && lista.Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Oznaka se ne može obrisati jer je postavljen na smjerovima: ");
                foreach (var e in lista)
                {
                    sb.Append(e.Smjer.Naziv).Append(", ");
                }

                throw new Exception(sb.ToString().Substring(0, sb.ToString().Length - 2));
            }
        }
       
    }
}
