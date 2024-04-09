using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdunovaAPP.Models
{
    // ORM čitati:https://github.com/tjakopec/ORM_JAVA_PHP_CSHARP

    /// <summary>
    /// Ovo mi je POCO koji je mapiran na bazu
    /// </summary>
    public class Smjer:Entitet
    {
        /// <summary>
        /// Naziv u bazi
        /// </summary>
        public string? Naziv { get; set; }

        /// <summary>
        /// Trajanje u satima
        /// </summary>
        [Column("brojsati")]
        public int? Trajanje { get; set; }

        /// <summary>
        /// Cijena u eurima
        /// </summary>
        public decimal? Cijena { get; set; }

        /// <summary>
        /// Iznos u Eurima
        /// </summary>
        public decimal? Upisnina { get; set; }
        
        /// <summary>
        /// Oznaka da li je smjer verificiran od strane ministarstva ili ne
        /// </summary>
        public bool? Verificiran { get; set; }
    }
}
