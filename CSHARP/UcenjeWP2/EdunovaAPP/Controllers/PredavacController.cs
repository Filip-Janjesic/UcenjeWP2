using EdunovaAPP.Data;
using EdunovaAPP.Extensions;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdunovaAPP.Controllers
{
   
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PredavacController : ControllerBase
    {
       
        private readonly EdunovaContext _context;
       
        public PredavacController(EdunovaContext context)
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
                var lista = _context.Predavaci.ToList();
                if(lista == null || lista.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(lista.MapPredavacReadList());
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
                var p = _context.Predavaci.Find(sifra);
                if (p == null)
                {
                    return new EmptyResult();
                }
                return new JsonResult(p.MapPredavacInsertUpdatedToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(PredavacDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid || dto == null)
            {
                return BadRequest();
            }
            try
            {
                var entitet = dto.MapPredavacInsertUpdateFromDTO(new Predavac());
                _context.Predavaci.Add(entitet);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, entitet.MapPredavacReadToDTO());
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }

       
        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, PredavacDTOInsertUpdate dto)
        {
            if(sifra<=0 || !ModelState.IsValid || dto == null)
            {
                return BadRequest();
            }


            try
            {


                var entitetIzBaze = _context.Predavaci.Find(sifra);

                if (entitetIzBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent,sifra);
                }

                var entitet = dto.MapPredavacInsertUpdateFromDTO(entitetIzBaze);

                _context.Predavaci.Update(entitetIzBaze);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,entitetIzBaze.MapPredavacInsertUpdatedToDTO());
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
                var entitetIzbaze = _context.Predavaci.Find(sifra);

                if (entitetIzbaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.Predavaci.Remove(entitetIzbaze); 
                _context.SaveChanges();

                return new JsonResult(new { poruka = "Obrisano" }); // ovo nije baš najbolja praksa ali da znake kako i to može

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }


        [HttpPatch]
        public async Task<ActionResult> Patch(int sifraPredavac, IFormFile datoteka)
        {
            if (datoteka == null)
            {
                return BadRequest();
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
                return new JsonResult(new { poruka = "Datoteka pohranjena" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, e.Message); 
            }
        }


    }
}
