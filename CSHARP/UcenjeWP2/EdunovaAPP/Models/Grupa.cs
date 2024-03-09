using System.ComponentModel.DataAnnotations.Schema;

namespace EdunovaAPP.Models
{
    public class Grupa:Entitet
    {
        public string? Naziv { get; set; }

        [ForeignKey("predavac")] // ovo pod navodnicima je naziv kolone u tablici grupa
        public Predavac? Predavac { get; set; }

        [ForeignKey("smjer")]
        public Smjer? Smjer { get; set; }

        public int? MaksimalnoPolaznika { get; set; }

        public DateTime? DatumPocetka { get; set; }

        public List<Polaznik>? Polaznici { get; set; }
    }
}
