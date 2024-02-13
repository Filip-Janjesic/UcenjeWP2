using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E12KlasaObjekt
{
    internal class Ljubav
    {

        public string PrvoIme { get; set; }
        public string DrugoIme { get; set; }

        // Ovo je konstruktor - 5. vrsta metoda
        public Ljubav() { 
        // ovdje se dolazi kada se izvodi ključna riječ new
        }

        public Ljubav(string prvoIme,string drugoIme) { 
            this.PrvoIme = prvoIme;
            DrugoIme= drugoIme;
        }

        public string Rezultat()
        {
            return Izracunaj(SlovaUNiz(PrvoIme+DrugoIme)) + " %";
        }

        private int[] SlovaUNiz(string Imena)
        {
            // fiksno
            return new int[2];
        }

        private int Izracunaj(int[] Brojevi)
        {
            // ovo je sad fiksno, tu dolazi rekurzivni algoritam
            return 67;
        }

    }
}
