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


            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Console.Write((i+1) * (j+1) + " ");
                }
                Console.WriteLine();
            }
            // DZ popraviti formatiranje
            // DZ skužiti kako nasilno prekinuti iz unutarnje petlje vanjsku


            // Petlja se može preskočiti

            for(int i = 0; i < 10; i++)
            {
                if(i%3== 0)
                {
                    continue;
                }

                Console.WriteLine(i);
            }

            // petlja se može nasilno prekinuta
            for(int i=0;i< 10; i++)
            {
                if (i == 3)
                {
                    break;
                }
                Console.WriteLine(i);
            }



            // beskonačna petlja
            for(; ; )
            {
                Console.Write(new Random().Next(10,100) + " ");
                Console.Write(new Random().Next(10, 100) + " ");
                Console.Write(new Random().Next(10, 100) + " ");
                Console.Write(new Random().Next(10, 100) + " ");
                Console.Write(new Random().Next(10, 100) + " ");
                Console.Write(new Random().Next(10, 100) + " ");
                Console.Write(new Random().Next(10, 100) + " ");
                Thread.Sleep(50);
                break;
            }



            // Za uneseni broj između 1 i 10
            // ispiši taj broj na kvadrat

            //int broj;

            //for(; ; )
            //{
            //    Console.Write("Unesi broj između 1 i 10: ");
            //    broj = int.Parse(Console.ReadLine());
            //    if(broj>=1 && broj <= 10)
            //    {
            //        break;
            //    }
            //    Console.WriteLine("Dragi korisniče, krivi unos!");
            //}

            //Console.WriteLine(broj*broj);


            // 9 različitih načina zbaranja prvih 100 brojeva

            //int i, s=0; for(i=1;i<=100;i++) s+=i;

            // int i, s; for(i=1, s=0;i<=100; s+=i, i++);
            //
            // int i=1, s=0; for( ; i<=100; i++){ s+=i; }
            //
            // int i, s=0; for(i=1; ; i++){ if(i<=100) s+=i; else break;}
            //
            // int i, s=0; for(i=1;i<=100;){ s+=i; i++;}
            //
             //int i, s=0; for(i=1; ; ){ if(i<=100) {s+=i; i++;} else break;}
            //
            // int i=1, s=0; for( ; i<=100 ; ){ s+=i; i++;}
            //
            // int i=1, s=0; for( ; ; i++){if(i<=100)  s+=i; else break;}
            //
            // int i=1, s=0; for( ;  ; ){if(i<=100) {s+=i; i++;} else break;} 
            //		

            










            // kraj metode
        }
    }
}
