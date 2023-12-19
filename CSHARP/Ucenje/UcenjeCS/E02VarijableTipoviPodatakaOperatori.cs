namespace UcenjeCS
{
    internal class E02VarijableTipoviPodatakaOperatori
    {

        public static void Izvedi()
        {
            int Varijabla = 3;

            Console.WriteLine(Varijabla);

            int i=1, j=0, k;

            Console.WriteLine("{0} - {1}",i,j);

            bool Istina = i == 1;

            Console.WriteLine(Istina);

            double Broj = 4.89;
            decimal VeciBroj = 2.89M;

            // brojevi se nalaze na brojevnoj kružnici
            Console.WriteLine(int.MaxValue);
            int Mb = int.MaxValue;
            Console.WriteLine(Mb+1);

            i = 3; j = 2; k = 1;

            Console.WriteLine(i+j);
            Console.WriteLine(i-j);
            Console.WriteLine(i*j); //množenje
            Console.WriteLine(i/j); //djeljenje - daje cijeli broj
            Console.WriteLine((float)i/j); // djeljenje s decimalnim rezultatom

            // za dvoznamenkasti broj ispišu prvu znamenku
            int db = 56;
            Console.WriteLine(db/10);

            bool uvjet = i > j;
            uvjet = i >= j;
            uvjet = i <= j;
            uvjet = i < j;
            uvjet = i == j; // provjera jednakosti
            uvjet = i!=j; // provjera ne jednakosti


            // operator modulo
            // ostatak nakon cjelobrojnog djeljenja
            int ostatak = 9 % 2;

            // za dvoznamenskasti broj ispiši vrijednost jedinice
            Console.WriteLine(52 % 10);

            i = 1;
            Console.WriteLine(i); //1
            i = i + 1; // uvećavam za 1
            Console.WriteLine(i); //2
            i += 1; // uvećavam za 1
            Console.WriteLine(i); //3
            i++; // uvećavam za 1
            Console.WriteLine(i); //4

            // specifičnosti incrementa ++
            // i++ prvo koristi trenutnu vrijednot pa onda uveća
            Console.WriteLine(i++);//4
            Console.WriteLine(i); //5
            // ++i prvo uveća pa onda koristi
            Console.WriteLine(++i); //6
            Console.WriteLine(i); //6

            // SVE VRIJEDI ISTOVJETNO i za dekrement (--)

            int t = 1, l = 2;
            t = ++t - l; // t = 0, l= 2
            Console.WriteLine("t = ++t - l => t={0}, l={1}", t, l);

           l -= t - l; // l = 2, t = 0
            Console.WriteLine("l -= t - l => t={0}, l={1}", t, l);

            
            Console.WriteLine(++t - --l); // 1 - 1 = 0
            Console.WriteLine("++t - --l => t={0}, l={1}", t, l);

            // Ovo vježbati doma na način
            // Prvo si postaviti zadatak pa ga nakon 15 minuta riješiti

        }

    }
}
