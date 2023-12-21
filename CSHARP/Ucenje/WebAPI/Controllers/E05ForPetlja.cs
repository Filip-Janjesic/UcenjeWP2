using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("E05")]
    public class E05ForPetlja:ControllerBase
    {
        [HttpGet]
        [Route("zad1")]
        public int[] Zad1( int brojevi)
        {
            // Ruta vraća niz s brojevima od 1 do brojevi
            int[] niz = new int[brojevi];
            for(int i = 0; i < brojevi; i++)
            {
                niz[i] = i+1;
            }
            
            return niz;
            
        }


       
    }
}
