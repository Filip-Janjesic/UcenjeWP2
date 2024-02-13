using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E13Nasljedivanje
{
    internal class Polaznik:Osoba // Klasa Polaznik nasljeđuje sva javna i zaštićena svojstva iz klase Osoba
    {
        private int Vidim;
        public string BrojUgovora { get; set; }

        public Polaznik():base() // ovo i ne terba eksplicitno navesti
        {
            Console.WriteLine("Konstruktor polaznika");
        }

        public Polaznik(int sifra, string ime, string prezime, string oib,
                 string email,string brojUgovora)
            :base(sifra,ime,prezime,oib,email)
        {
            BrojUgovora = brojUgovora;
            //base.Sifra= sifra; // ovo me tu nije mjesto, to mora odraditi Klasa u kojoj se nalazi svojtsvo Sifra
        }


        public override string ToString()
        {
            return new StringBuilder(base.ToString()).
                Append(',').Append(BrojUgovora).ToString();
        }




        private void ProvjeraVidljivosti()
        {
            Vidim = 2; //ovo je u mojoj klasi
            base.Sifra = 2;
            base.Vidim = 7; // ovo je u nadklasi
            this.Vidim = 8; // ovo je u mojoj klasi
            //NeVidim // se ne vidi
        }
    }
}
