using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E12KlasaObjekt
{
    internal class Program
    {

        public static void Izvedi()
        {
            Osoba o = new Osoba();
            Grad g = new()
            {
                //Naziv="Osijek",
                BrojStanovnika=100000
            };

            o.Grad = g;

            // kako ću na instanci klase Osoba ispisati Osijek
            Console.WriteLine(o.Grad?.Naziv);

        }

        private static void E04LjubavniZov()
        {
            Ljubav ljubav = new(); //s new se poziva konstruktor

            //Console.Write("Unesi ime prve osobe: ");
            //ljubav.PrvoIme = Console.ReadLine();
            ljubav.PrvoIme = Unos("Unesi ime prve osobe: ");
            ljubav.DrugoIme = Unos("Unesi ime druge osobe: ");

            Console.WriteLine(ljubav.Rezultat());

            Console.WriteLine(new Ljubav(Unos("PI"), Unos("DI")).Rezultat());


        }

        private static string Unos(string poruka)
        {
            string unos;
            while (true)
            {
                Console.Write(poruka);
                unos = Console.ReadLine();
                if (unos.Trim().Length == 0)
                {
                    Console.WriteLine("Unos obavezan");
                    continue;
                }
                return unos;
            }
        }

        private static void E03Najcesce()
        {
            // najčešći način deklaracije
            // umjesto Osoba osoba = new Osoba();
            Osoba osoba = new();

            var pjevac = new Osoba();

            //pjevac.Ime = "Mirko";
            Console.WriteLine(pjevac.Ime?.Substring(0, 1));
        }

        private static void E02DrugaSintaksa()
        {
            Osoba o = new Osoba
            {
                Ime = Console.ReadLine(), // ovdje sam učitao ime s konzole
                Prezime = Console.ReadLine()
            };


            Console.WriteLine(o.ImePrezime());
        }

        private static void E01OsnovnaSintaksa()
        {
            // Objekt je pojavnost (instanca) klase
            Osoba osoba = new Osoba();

            osoba.Ime = "Pero";
            osoba.Prezime = "Perić";

            Console.WriteLine(osoba.Ime);
        }

    }
}
