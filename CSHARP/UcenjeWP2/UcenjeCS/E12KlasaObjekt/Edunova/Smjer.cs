using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E12KlasaObjekt.Edunova
{
    // POCO klasa
    internal class Smjer
    {
        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public int BrojSati { get; set; }
        public float Cijena { get; set; }
        public float Upisnina { get; set; }
        public bool verificiran { get; set; }
    }
}
