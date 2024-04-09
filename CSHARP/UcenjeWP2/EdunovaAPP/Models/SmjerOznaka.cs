using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdunovaAPP.Models
{

    public class SmjerOznaka:Entitet
    {
        [ForeignKey("smjer")]
        public Smjer? Smjer { get; set; }
        [ForeignKey("oznaka")]
        public Oznaka? Oznaka { get; set; }
        public string? napomena { get; set; }


    }
}
