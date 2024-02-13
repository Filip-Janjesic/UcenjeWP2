namespace UcenjeCS
{
    internal class E03UvjetnaGrananja
    {
        public static void Izvedi()
        {
            int i = 7; // Namjerno ne radim čitanje iz COnsole kako bi dobili na vremenu

            // Binarno grananje

            bool uvjet = i == 7;


            // uvjet ima vrijednost true
            if(uvjet)
            {
                Console.WriteLine($"broj je {i}, ušli smo u true dio if naredbe");
            }

            // ovo gore i sada sljedeće je minimalni dio if naredbe
            // inače se u pravilu ovako piše
            if(i == 7)
            {
                Console.WriteLine("Isti uvjet kao i prethodno");
            }

            // drugi dio if naredbe (neobavezni) else

            if (i < 5)
            {
                Console.WriteLine("i je manje od 5");
            }
            else
            {
                Console.WriteLine("i nije manje od 5");
            }


            // puni izgled if naredbe

            if (i == 2) {
                Console.WriteLine("i je 2");
            }else if (i == 3)
            {
                Console.WriteLine(3);
            }
            else
            {
                Console.WriteLine("i nije 2 niti je 3");
            }

            int j = 2;
            if (i == 7)
            {
                if(j==2)
                {
                    Console.WriteLine("Oba uvjeta su zadovoljena ugnježđeno");
                }
            }

            // korištenje logičkih operatora
            // logičko & i uvjetovano &&
            i = 5;
            if(i==7 & j == 2)
            {
                Console.WriteLine("Oba uvjeta su zadovoljena");
            }
            // & provjeravaju se oba uvjeta bez obzira ako se na prvom padne (false)

            if(i==7 && j== 2)
            {
                Console.WriteLine("Oba uvjeta su zadovoljena");
            }

            // && Ukoliko padne (false) na prvom uvjetu ne provjerava se drugi



            // logičko | i uvjetovano ||

            if(i==5 | j == 1)
            {
                Console.WriteLine("Dovoljno je da jedan od uvjeta bude zadovoljen");
            }
            // | provjerava oba uvjeta bez obzira ako je prvi proša (true)

            if(i==5 || j== 1)
            {
                Console.WriteLine("Prvi uvjet zadovoljen, drugi se ne provjerava");
            }
            // || Ukoliko prvi uvjet prođe (true) drugi se ne provjerava

            // logično NE (!)
            if((i== 5 || j== 1) && !(i>5 || j < 8))
            {
                Console.WriteLine("Komplicirani izraz");
            }

            // skraćeni način pisanja: inline if

            // Program upisuje cijeli broj
            // Ako je broj veći od 10 ispisuje Osijek
            // Inače ispisuje Zagreb
            Console.Write("Unesi cijeli broj: ");
            int broj = int.Parse(Console.ReadLine());

            if (broj > 10)
            {
                Console.WriteLine("Osijek");
            }else 
            { 
                Console.WriteLine("Zagreb");
            }

            // u slučaju istog ponašanja s različitim vrijednostima u if i else dijelu
            // možemo pisati kraće

            // inline if
            Console.WriteLine(i>10 ? "Osijek" : "Zagreb");



            // višestruko grananje
            int ocjena = 4;

            switch(ocjena)
            {
                case 1:
                    Console.WriteLine("Nedovoljan");
                    break;
                case 2:
                    case 3:
                    Console.WriteLine("Dovoljno ili dobro");
                    break;
                case 4: case 5:
                    Console.WriteLine("To je ocjena");
                    break;
                default:
                    Console.WriteLine("Nije ocjena");
                    break;
            }

            string ime = "Pero";
            switch(ime)
            {
                case "Marko":
                    Console.WriteLine("OK");
                    break;
                case "Pero":
                    Console.WriteLine("Super");
                    break;
            }

        }
    }
}
