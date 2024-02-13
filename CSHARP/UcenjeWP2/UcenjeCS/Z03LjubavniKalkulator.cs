using System;

namespace UcenjeCS
{
    internal class Z03Ljubavnikalkulator
    {
        public static void Izvedi()
        {
            Console.WriteLine("Test Ljubavi");

            Console.Write("Unesi svoje ime: ");
            string tvojeIme = Console.ReadLine();

            Console.Write("Unesi ime svoje simpatije: ");
            string simpatijaIme = Console.ReadLine();

            Console.WriteLine();

            // Izračunaj zbroj pojavljivanja slova za prvo ime i simpatiju
            int zbrojPojavljivanja = ZbrojPojavljivanjaSlova(tvojeIme, simpatijaIme);

            Console.WriteLine($"Zbroj pojavljivanja slova: {zbrojPojavljivanja}");

            // Izračunaj postotak šanse za ljubav
            double postotakSanse = IzracunajPostotakSanse(zbrojPojavljivanja);

            Console.WriteLine($"Postotak šanse za ljubav: {postotakSanse}%");
        }

        static int ZbrojPojavljivanjaSlova(string ime1, string ime2, int indeks = 0)
        {
            // Ako smo došli do kraja imena, vrati 0
            if (indeks == ime1.Length)
                return 0;

            // Izračunaj broj pojavljivanja trenutnog slova u oba imena
            int pojavljivanja = BrojPojavljivanjaSlova(ime1[indeks], ime1) + BrojPojavljivanjaSlova(ime1[indeks], ime2);

            // Rekurzivno pozovi funkciju za sljedeći indeks
            return pojavljivanja + ZbrojPojavljivanjaSlova(ime1, ime2, indeks + 1);
        }

        static int BrojPojavljivanjaSlova(char slovo, string tekst, int indeks = 0)
        {
            // Ako smo došli do kraja teksta, vrati 0
            if (indeks == tekst.Length)
                return 0;

            // Ako je trenutni karakter jednak traženom slovu, povećaj broj pojavljivanja
            int pojavljivanje = (tekst[indeks] == slovo) ? 1 : 0;

            // Rekurzivno pozovi funkciju za sljedeći indeks
            return pojavljivanje + BrojPojavljivanjaSlova(slovo, tekst, indeks + 1);
        }

        static double IzracunajPostotakSanse(int zbrojPojavljivanja)
        {
            // Prilagodi zbroj na raspon od 0 do 100
            zbrojPojavljivanja = Math.Min(Math.Max(zbrojPojavljivanja, 0), 100);

            // Izračunaj postotak šanse za ljubav
            return 100.0 - Math.Abs(50 - zbrojPojavljivanja);
        }
    }
}
