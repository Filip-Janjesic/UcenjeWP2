using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E14Polimorfizam
{
    internal class Grupa: Entitet
    {
        public string Naziv { get; set; }
        public Predavac Predavac { get; set; }
        public Smjer Smjer { get; set; }
        public int MaksimalnoPolaznika { get; set; }
        public DateTime DatumPocetka { get; set; }

        public List<Polaznik> Polaznici { get; set; }

    }
}
