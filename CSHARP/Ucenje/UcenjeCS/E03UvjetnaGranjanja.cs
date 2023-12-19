
namespace UcenjeCS
{
    internal class E03UvjetnaGranjanja
    {

        public static void Izvedi()
        {
            int i = 7;

            bool uvjet = i == 7;

            if (uvjet)
            {
                Console.WriteLine("Ušao sam u true dio if naredbe");
            }

            if(i == 7)
            {
                Console.WriteLine("Isto kao i prije");
            }

            if(i < 5)
            {
                Console.WriteLine("i je manje od 5");
            }
            else
            {
                Console.WriteLine("i nije manje od 5");
            }

            int j = 2;
            if (i == 7)
            {
                if (j==2)
                {
                    Console.WriteLine("Oba uvijeta zadovoljena");
                }
            }

            Console.WriteLine("Unesi cijeli broj: ");
            int broj = int.Parse(Console.ReadLine());

            if (broj > 10)
            {
                Console.WriteLine("Osijek");
            }
            else
            {
                Console.WriteLine("Zagreb");
            }

        }
    }
}

