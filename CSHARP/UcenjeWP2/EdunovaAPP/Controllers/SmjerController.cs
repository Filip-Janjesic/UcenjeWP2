using EdunovaAPP.Data;
using EdunovaAPP.Extensions;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EdunovaAPP.Controllers
{
    /// <summary>
    /// Namjenjeno za CRUD operacije nad entitetom smjer u bazi
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SmjerController : ControllerBase
    {
        /// <summary>
        /// Kontest za rad s bazom koji će biti postavljen s pomoću Dependecy Injection-om
        /// </summary>
        private readonly EdunovaContext _context;
        /// <summary>
        /// Konstruktor klase koja prima Edunova kontext
        /// pomoću DI principa
        /// </summary>
        /// <param name="context"></param>
        public SmjerController(EdunovaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Dohvaća sve smjerove iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita
        /// 
        ///    GET api/v1/Smjer
        ///    
        /// </remarks>
        /// <returns>Smjerovi u bazi</returns>
        /// <response code="200">Sve OK, ako nema podataka content-length: 0 </response>
        /// <response code="400">Zahtjev nije valjan</response>
        /// <response code="503">Baza na koju se spajam nije dostupna</response>
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
                var smjerovi = _context.Smjerovi.ToList();
                if(smjerovi==null || smjerovi.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(smjerovi.MapSmjerReadList());
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
            if (!ModelState.IsValid || sifra<=0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var smjer = _context.Smjerovi.Find(sifra);
                if (smjer == null)
                {
                    return new EmptyResult();
                }
                return new JsonResult(smjer.MapSmjerInsertUpdatedToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }

        /// <summary>
        /// Dodaje novi smjer u bazu
        /// </summary>
        /// <remarks>
        ///     POST api/v1/Smjer
        ///     {naziv: "Primjer naziva"}
        /// </remarks>
        /// <param name="smjer">Smjer za unijeti u JSON formatu</param>
        /// <response code="201">Kreirano</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Baza nedostupna iz razno raznih razloga</response> 
        /// <returns>Smjer s šifrom koju je dala baza</returns>
        [HttpPost]
        public IActionResult Post(SmjerDTOInsertUpdate smjerDTO)
        {
            if (!ModelState.IsValid || smjerDTO == null)
            {
                return BadRequest();
            }
            try
            {
                var smjer = smjerDTO.MapSmjerInsertUpdateFromDTO(new Smjer());
                _context.Smjerovi.Add(smjer);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, 
                    smjer.MapSmjerReadToDTO());
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }

        /// <summary>
        /// Mijenja podatke postojećeg smjera u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/smjer/1
        ///
        /// {
        ///  "sifra": 0,
        ///  "naziv": "Novi naziv",
        ///  "trajanje": 120,
        ///  "cijena": 890.22,
        ///  "upisnina": 0,
        ///  "verificiran": true
        /// }
        ///
        /// </remarks>
        /// <param name="sifra">Šifra smjera koji se mijenja</param>  
        /// <param name="smjer">Smjer za unijeti u JSON formatu</param>  
        /// <returns>Svi poslani podaci od smjera koji su spremljeni u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi smjera kojeg želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Baza nedostupna</response> 
        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, SmjerDTOInsertUpdate smjerDTO)
        {
            if(sifra<=0 || !ModelState.IsValid || smjerDTO == null)
            {
                return BadRequest();
            }


            try
            {


                var smjerIzBaze = _context.Smjerovi.Find(sifra);

                if (smjerIzBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent,sifra);
                }
                
                var smjer = smjerDTO.MapSmjerInsertUpdateFromDTO(smjerIzBaze);
 

                _context.Smjerovi.Update(smjer);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,smjer.MapSmjerReadToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }

        /// <summary>
        /// Briše smjer iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    DELETE api/v1/smjer/1
        ///    
        /// </remarks>
        /// <param name="sifra">Šifra smjera koji se briše</param>  
        /// <returns>Odgovor da li je obrisano ili ne</returns>
        /// <response code="200">Sve je u redu, obrisano je u bazi</response>
        /// <response code="204">Nema u bazi smjera kojeg želimo obrisati</response>
        /// <response code="503">Problem s bazom</response> 
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
                var smjerIzbaze = _context.Smjerovi.Find(sifra);

                if (smjerIzbaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.Smjerovi.Remove(smjerIzbaze); 
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
