using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E15KonzolnaAplikacijaPreustroj.Model
{
    internal class Predavac : Osoba
    {
        public string IBAN { get; set; }

        public override string ToString ()
        {
            return Ime + " " + Prezime + " || " + "OIB: " + Oib + " || " + "Email: " + Email + " || " + "IBAN: " + IBAN;
        }

    }
}
