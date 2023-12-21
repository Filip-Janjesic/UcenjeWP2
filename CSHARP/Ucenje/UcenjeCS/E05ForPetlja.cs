namespace UcenjeCS
{
    internal class E05ForPetlja
    {
        public static void Izvedi()
        {

            // Ispisati 10 puta Edunova
            // ovo je najgore moguće rješenje
            //Console.WriteLine("Edunova");
            //Console.WriteLine("Edunova");
            //Console.WriteLine("Edunova");
            //Console.WriteLine("Edunova");
            //Console.WriteLine("Edunova");
            //Console.WriteLine("Edunova");
            //Console.WriteLine("Edunova");
            //Console.WriteLine("Edunova");
            //Console.WriteLine("Edunova");
            //Console.WriteLine("Edunova");


            // for (od kuda; do kuda; uvećanje/umanjenje)
            for(int i = 0; i < 100; i++)
            {
                Console.WriteLine("Edunova");
            }

            // varijabla izvan petlje
            int t;
            for(t=0;t<10; t++)
            {
                Console.WriteLine("Edunova T");
            }


            // varijabla u petlji mijenja vrijednost

            for(int i=0; i<10; i++) 
            {
                Console.WriteLine(i+1);
            }



            // Ne mora biti uvećanje, može i umanjenje
            for(int i = 10; i > 0; i--)
            {
                Console.WriteLine(i);
            }


            // korak uvećanja/umanjenja može biti veći od 1

            for(int i = 0; i < 20; i += 2)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("**************");
            // ispisati sve parne brojeve između 3 i 23

            int ukpb = 56;
            int ukdb = 56;


            int manji = ukpb < ukdb ? ukpb : ukdb;
            int veci = ukpb > ukdb ? ukpb : ukdb;

            if (manji == veci && manji%2!=0)
            {
                Console.WriteLine("Unijeli ste iste brojeve, nema ispisa parnih brojeva");
            }

            for(int i = manji; i <= veci; i++)
            {
                if(i%2 == 0)
                {
                    Console.WriteLine(i);
                }
            }









        }
    }
}
