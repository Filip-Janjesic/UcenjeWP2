using System;

namespace UcenjeCS
{
    internal class V01ZimskoVjezbanje
    {
        public static void Izvedi()
        {
            // Ispis brojeva od 1 do 100
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i);
            }

            // Ispis brojeva od 100 do 1
            for (int i = 100; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
