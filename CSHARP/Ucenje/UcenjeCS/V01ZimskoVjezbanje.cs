using System;

namespace UcenjeCS
{
    internal class V01ZimskoVjezbanje
    {
        public static void Izvedi()
        {
            // 1. Napisati program koji ispisuje sve brojeve od 1 do 100
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i);
            }

            // 2. Napisati program koji ispisuje sve brojeve od 100 do 1 
            for (int i = 100; i >= 1; i--)
            {
                Console.WriteLine(i);
            }

            // 3. Napisati program koji ispisuje sve brojeve od 1 do 100 koji su cjelobrojno djeljivi s 7
            for (int i = 1; i <= 100; i++)
            {
                if (i % 7 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            // 4. Napisati program koji unosi brojeve sve dok ne unese broj veći od 100, a zatim ispisuje koliko je bilo pokušaja unosa
            int brojPokusaja = 0;

            Console.WriteLine("Unesite brojeve. Unesite broj veći od 100 za završetak.");

            while (true)
            {
                Console.Write("Unesite broj: ");
                string unos = Console.ReadLine();

                if (int.TryParse(unos, out int broj))
                {
                    brojPokusaja++;

                    if (broj > 100)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Nevažeći unos. Molimo unesite celi broj.");
                }
            }

            Console.WriteLine($"Broj pokušaja unosa: {brojPokusaja}");
        }
    }
}