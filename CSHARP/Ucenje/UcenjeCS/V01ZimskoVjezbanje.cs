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

            for (int i = 1; i <= 100; i++)
            {
                if (i % 7 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
