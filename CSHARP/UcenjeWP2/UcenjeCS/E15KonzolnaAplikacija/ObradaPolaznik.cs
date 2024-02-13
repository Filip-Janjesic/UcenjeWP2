using UcenjeCS.E15KonzolnaAplikacija.Model;

namespace UcenjeCS.E15KonzolnaAplikacija

{
    internal class ObradaPolaznik
    {
        public List<Polaznik> Polaznici { get; }

        public ObradaPolaznik() 
        { 
            Polaznici = new List<Polaznik>();
            if (Pomocno.dev)
            {
                TestniPodaci();
            }
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s polaznicima");
            Console.WriteLine("1. Pregled postojećih polaznika");
            Console.WriteLine("2. Unos novog polaznika");
            Console.WriteLine("3. Promjena postojećeg polaznika");
            Console.WriteLine("4. Brisanje polaznika");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika polaznika: ",
                "Odabir mora biti 1-5", 1, 5))
            {
                
                case 1:
                    PregledPolaznika();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UcitajPolaznika();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjenaPolaznika();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjePolaznika();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s polaznicima");
                    break;


            }
        }

        private void PromjenaPolaznika()
        {
            PregledPolaznika();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj polaznika: ", "Nije dobar odabir", 1, Polaznici.Count());
            var p = Polaznici[index - 1];
            p.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifra polaznika (" + p.Sifra + "): ",
                "Unos mora biti pozitivni cijeli broj");
            p.Ime = Pomocno.UcitajString("Unesi ime polaznika (" + p.Ime + "): ", "Ime obavezno");
            p.Prezime = Pomocno.UcitajString("Unesi Prezime polaznika (" + p.Prezime + "): ", "Prezime obavezno");
            p.Email = Pomocno.UcitajString("Unesi Email polaznika (" + p.Email + "): ", "Email obavezno");
            p.Oib = Pomocno.UcitajString("Unesi OIB polaznika (" + p.Oib + "): ", "OIB obavezno");
        }

        private void BrisanjePolaznika()
        {
            PregledPolaznika();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj polaznika: ", "Nije dobar odabir", 1, Polaznici.Count());
            Polaznici.RemoveAt(index - 1);
        }

        public void PregledPolaznika()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("---- Polaznici ----");
            Console.WriteLine("------------------");
            int b = 1;
            foreach (Polaznik polaznik  in Polaznici)
            {
                Console.WriteLine("{0}. {1}", b++, polaznik);
            }
            Console.WriteLine("------------------");
        }

        private void UcitajPolaznika()
        {
            var p = new Polaznik();
            p.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifra polaznika: ",
                "Unos mora biti pozitivni cijeli broj");
            p.Ime = Pomocno.UcitajString("Unesi ime polaznika: ", "Ime obavezno");
            p.Prezime = Pomocno.UcitajString("Unesi Prezime polaznika: ", "Prezime obavezno");
            p.Email = Pomocno.UcitajString("Unesi Email polaznika: ", "Email obavezno");
            p.Oib = Pomocno.UcitajString("Unesi OIB polaznika: ", "OIB obavezno");
            Polaznici.Add(p);

        }

        private void TestniPodaci()
        {
            Polaznici.Add(new Polaznik
            {
                Sifra = 1,
                Ime = "Ana",
                Prezime="Gal",
                Email="agal@gmail.com",
                Oib="33736472822"
            });

            Polaznici.Add(new Polaznik
            {
                Sifra = 2,
                Ime = "Marija",
                Prezime = "Zimska",
                Email = "mzimska@gmail.com",
                Oib = "33736472821"
            });
        }
    }
}
