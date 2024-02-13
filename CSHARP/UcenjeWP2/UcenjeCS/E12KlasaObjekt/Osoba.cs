using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E12KlasaObjekt
{
    // Klase je opisnik objekta - NAUČITI NAPAMET
    internal class Osoba
    {
        // svojstva koja opisuju klasu
        public string? Ime { get; set; }
        public string Prezime { get; set; }

        public Grad Grad { get; set; }

        public string ImePrezime()
        {
            return Ime + " " + Prezime; // ovo može bolje
        }

    }
}
