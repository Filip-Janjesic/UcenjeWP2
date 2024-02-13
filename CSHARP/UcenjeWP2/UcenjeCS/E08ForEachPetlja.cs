using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class E08ForEachPetlja
    {
        public static void Izvedi()
        {
            int[] Niz = { 1, 2, 3 };

            for(int i = 0;i<Niz.Length; i++)
            {
                Console.WriteLine(Niz[i]);
            }
            
            // gornji kod je ekvivalent donjem

            foreach(int Element in Niz)
            {
                Console.WriteLine(Element);
            }

            Console.WriteLine("------------");

            // sve ostale značajke petlji jednako funkcioniraju

            // tip podatka string

            string Ime = "Edunova a čšćđžČŠĆĐŽ";

            Console.WriteLine(Ime);

            foreach(char c in Ime)
            {
                Console.WriteLine(c + ": " + (int)c);
            }


            Console.WriteLine("------------");


            // Korisnik unosi tekst a program ispisuje
            // koje slovo je unio koliko puta
            // Osijek je super grad
            // O 1
            // s 2
            // i 1
            // j 2
            // ....
            Console.Write("Unesi tekst: ");
            string Unos = Console.ReadLine();

            Console.WriteLine(Unos);

            int[] Slova = new int[Unos.Length];
            int index = 0;
            int ukupno;
            foreach (char c in Unos)
            {
                ukupno = 0;
                foreach(char cc in Unos)
                {
                    if (c == cc)
                    {
                        ukupno++;
                    }
                }
                Slova[index++] = ukupno;
            }

            Console.WriteLine(string.Join(",",Slova));

            char[] JedinstvenaSlova = new char[Unos.Length]; // ne treba mi toliko prostora, njaveći nedostatak nizova je taj što se na početku mora reći koliko ima elemenata
            bool postoji;
            index = 0;
            foreach (char c in Unos)
            {
                postoji = false;
                foreach(char cc in JedinstvenaSlova)
                {
                    if (c == cc)
                    {
                        postoji = true;
                        break;
                    }
                }
                if (!postoji)
                {
                    JedinstvenaSlova[index++] = c;
                }
            }

            Console.WriteLine(string.Join(",", JedinstvenaSlova));

            foreach (char c in JedinstvenaSlova)
            {
                Console.Write(c + " ");
                index = 0;

                foreach(char cc in Unos)
                {
                    if (c == cc)
                    {
                        Console.WriteLine(Slova[index]);
                        break;
                    }
                    index++;
                }
            }





        }
    }
}
