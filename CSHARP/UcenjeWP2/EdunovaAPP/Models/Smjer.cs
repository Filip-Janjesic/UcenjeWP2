using System.ComponentModel.DataAnnotations;

namespace EdunovaAPP.Models
{
    /// <summary>
    /// Ovo mi je POCO koji je mapiran na bazu
    /// </summary>
    public class Smjer:Entitet
    {
        /// <summary>
        /// Naziv u bazi
        /// </summary>
        [Required(ErrorMessage ="Naziv obavezno")]
        public string? Naziv { get; set; }
    }
}
