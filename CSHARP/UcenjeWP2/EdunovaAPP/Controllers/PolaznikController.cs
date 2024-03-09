using EdunovaAPP.Data;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdunovaAPP.Controllers
{
   
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PolaznikController : ControllerBase
    {
       
        private readonly EdunovaContext _context;
       
        public PolaznikController(EdunovaContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IActionResult Get()
        {
            // kontrola ukoliko upit nije valjan
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var lista = _context.Polaznici.ToList();
                if(lista == null || lista.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(lista);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, 
                    ex.Message);
            } 
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            // kontrola ukoliko upit nije valjan
            if (!ModelState.IsValid || sifra <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var p = _context.Polaznici.Find(sifra);
                if (p == null)
                {
                    return new EmptyResult();
                }
                return new JsonResult(p);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(Polaznik entitet)
        {
            if (!ModelState.IsValid || entitet == null)
            {
                return BadRequest();
            }
            try
            {
                _context.Polaznici.Add(entitet);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, entitet);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }

       
        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Polaznik entitet)
        {
            if(sifra<=0 || !ModelState.IsValid || entitet == null)
            {
                return BadRequest();
            }


            try
            {


                var entitetIzBaze = _context.Polaznici.Find(sifra);

                if (entitetIzBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent,sifra);
                }


                // inače ovo rade mapperi
                // za sada ručno
                entitetIzBaze.Ime = entitet.Ime;
                entitetIzBaze.Prezime= entitet.Prezime;
                entitetIzBaze.Oib= entitet.Oib;
                entitetIzBaze.Email= entitet.Email;
                entitetIzBaze.BrojUgovora=entitet.BrojUgovora;

                _context.Polaznici.Update(entitetIzBaze);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,entitetIzBaze);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }

       
        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if(!ModelState.IsValid || sifra <= 0)
            {
                return BadRequest();
            }

            try
            {
                var entitetIzbaze = _context.Polaznici.Find(sifra);

                if (entitetIzbaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.Polaznici.Remove(entitetIzbaze); 
                _context.SaveChanges();

                return new JsonResult(new { poruka = "Obrisano" }); // ovo nije baš najbolja praksa ali da znake kako i to može

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }



    }
}
