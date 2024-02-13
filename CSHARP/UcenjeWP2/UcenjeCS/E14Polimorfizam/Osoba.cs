using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E14Polimorfizam
{
    internal abstract class Osoba:Entitet
    {
        public abstract string Pozdravi();
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Oib { get; set; }

        public string Email { get; set; }
    }
}
