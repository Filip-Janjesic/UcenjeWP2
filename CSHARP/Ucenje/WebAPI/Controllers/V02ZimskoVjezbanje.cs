using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("VO2")]

    // 1. Ruta ne prima niti jedan parametar i vraća zbroj prvih 100 brojeva
    public class V02ZimskoVjezbanje : ControllerBase
    {
        [HttpGet]
        [Route("vjezba1")]
        public IActionResult Vjezba1()
        {
            int zbroj = Enumerable.Range(1, 100).Sum();
            return Ok($"Zbroj prvih 100 brojeva je: {zbroj}");
        }
    }
}
