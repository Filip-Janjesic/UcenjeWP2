using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("E01")]
    public class E01UlazIzlaz : ControllerBase
    {

        [HttpGet]
        [Route("Hello")]
        public string Helloworld(string Ime,int Godine, bool aktivan)
        {
            return "Upisali ste " + Ime + ", koji ima " + Godine + " godina, " + aktivan;
        }

    }
}