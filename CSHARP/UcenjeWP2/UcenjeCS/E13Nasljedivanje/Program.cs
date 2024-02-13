using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E13Nasljedivanje
{
    internal class Program
    {
        public static void Izvedi()
        {
            var p = new Polaznik()
            {
                Sifra = 1,
                Ime = "Pero",
                Prezime = "Perić",
                BrojUgovora="2/2024"
            };

            
            

            // Ispisati 1 iz objekta p

            var pr1 = new Predavac();
            pr1.Ime = "Mario";

            var pr2 = new Predavac();
            pr2.Ime = "Mario";

           

            Console.WriteLine((pr1==pr2) + ", " + pr1.GetHashCode() 
                + " == " + pr2.GetHashCode());

            //var e  = new Entitet(); NE MOGU INSTANCIRATI APSTRAKTNU KLASU
            //e.Sifra = 2;



            string a = "Osijek";
            Console.WriteLine("a na početku: " + a.GetHashCode());
            a += " je super";
            Console.WriteLine("a nakon promjene: " + a.GetHashCode());

            Console.WriteLine("pr1 na početku: " + pr1.GetHashCode());
            pr1.Prezime = "Perić";
            Console.WriteLine("pr1 nakon promjene: " + pr1.GetHashCode());


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Osijek");
            Console.WriteLine("sb na početku: " + sb.GetHashCode());
            sb.AppendLine(" je super");
            Console.WriteLine("sb nakon promjene: " + sb.GetHashCode());
            Console.WriteLine(sb.ToString());

            Console.WriteLine(pr1);
            Console.WriteLine(p);


           




        }
    }
}
