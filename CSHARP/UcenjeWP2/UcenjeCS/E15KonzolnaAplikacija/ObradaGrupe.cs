using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UcenjeCS.E15KonzolnaAplikacijaPreustroj.Model;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace UcenjeCS.E15KonzolnaAplikacijaPreustroj
{
    internal class ObradaGrupe

    {

        public List<Grupa> Grupe {  get;  }

        public List<Smjer> Smjerovi { get; }    
        public List<Polaznik> Polaznici { get; }
        public List<Predavac> Predavaci {  get; }   

        private Izbornik Izbornik { get; }

        private ObradaPolaznik ObradaPolaznik { get; }
        private ObradaSmjer ObradaSmjer { get; }
        private ObradaPredavac ObradaPredavac { get; set; }

        public ObradaGrupe(Izbornik izbornik):this()
        {
            this.Izbornik = izbornik;
           

        }

        public ObradaGrupe(ObradaPolaznik obradaPolaznik, ObradaSmjer obradaSmjer, ObradaPredavac obradaPredavac):this()
        {
            this.ObradaPolaznik = obradaPolaznik;
            this.ObradaSmjer = obradaSmjer;
            this.ObradaPredavac = obradaPredavac;
           
        }


        public ObradaGrupe ()
        {
            Grupe = new List<Grupa>();
            //if(Pomocno.dev)
            //{
            //    TestniPodaci(); 
            //}

        }

       

        public void IzbornikRadSGrupama ()
        {
            Console.WriteLine("\n" + "Izbornik grupe" +
                              "\n" +
                              "*****************************************************************");
            Console.WriteLine("1. Prikazi sve grupe");
            Console.WriteLine("2. Dodaj grupu");
            Console.WriteLine("3. Uredi grupu");
            Console.WriteLine("4. Izbrisi grupu");
            Console.WriteLine("5. Prikazi sve polaznike grupe");
            Console.WriteLine("6. Izbrisi polaznika iz grupe");

            Console.WriteLine("7. Ukupno polaznika na svim grupama");
            Console.WriteLine("8. Prosjecan broj polaznika u grupama");
            Console.WriteLine("9. Ukupan iznos prihoda po smjerovima");
            Console.WriteLine("10. Prosjecan iznos prihoda po polazniku");

            Console.WriteLine("11. Povratak na glavni izbornik");

            OdabirRadSGrupama();
        }

        private void OdabirRadSGrupama ()
        {
            switch (Pomocno.UcitajInt("\n" + "Unesite svoj izbor: "))
            {
                case 1:
                    Console.WriteLine("\n" + "Prikazujem sve grupe" + "\n");
                    PrikaziGrupe();
                    IzbornikRadSGrupama();
                    break;
                case 2:
                    Console.WriteLine("\n" + "Dodajem novu grupu" + "\n");
                    DodajNovuGrupu();
                    break;
                case 3:
                    Console.WriteLine("\n" + "Uredujem grupu" + "\n");
                    UrediGrupu();
                    break;
                case 4:
                    Console.WriteLine("\n" + "Izbrisi grupu" + "\n");
                    IzbrisiGrupu();
                    break;
                case 5:
                    Console.WriteLine("\n" + "Prikazujem polaznike grupe" + "\n");
                    PrikaziSvePolaznikeOdabraneGrupe();
                    IzbornikRadSGrupama();
                    break;
                case 6:
                    Console.WriteLine("\n" + " Brisem polaznika iz grupe" + "\n");
                    IzbrisiPolaznikaIzGrupe();
                    break;
                case 7:
                    Console.WriteLine("Ukupan broj polaznika na svim grupama");
                    UcitajUkupanBrojPolaznika(Grupe);

                    break;
                case 8:
                    Console.WriteLine("Prosjecan broj polaznika u grupama");
                    ProsjecanBrojPolaznikaUGrupama(Grupe);
                    break;
                    case 9:
                    Console.WriteLine("Ukupan iznos prihoda po smjerovima");
                    IznosPrihodaPoSmjerovima(Grupe);
                    break;
                    case 10:
                    Console.WriteLine("Prosjecan iznos prihoda po polazniku");
                    ProsjecanIznosPrihodaPoPolazniku();
                    break;
                case 11:
                    Izbornik.GlavniIzbornik(); 
                    break;
                default:
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!! KRIVI UNOS !!!!!!!!!!!!!!!!!!!!!");
                    IzbornikRadSGrupama();
                    break;
            }

        }


        private void IzbrisiPolaznikaIzGrupe ()
        {
            PrikaziSvePolaznikeOdabraneGrupe();
            var g = Grupe[Grupe.Count() - 1];
            int a = Pomocno.UcitajInt("Odaberi polaznika kojeg zelite obrizati: ") - 1;

            bool potvrda = Pomocno.UcitajBool("\n" + "Obrisati polaznika " + "\n" + g.Polaznici[a] + "\n" + "1) DA / 2) NE | ");

            if (potvrda == true)
            {
                g.Polaznici.RemoveAt(a);
            }

            IzbornikRadSGrupama();
        }

        private void IzbrisiGrupu ()
        {
            PrikaziGrupe();
            int a = Pomocno.UcitajInt("Odaberi polaznika kojeg zelite obrizati: ") - 1;
            bool potvrda = Pomocno.UcitajBool("\n" + "Obrisati polaznika " + "\n" + Grupe[a] + "\n" + "1) DA / 2) NE | ");

            if (potvrda == true)
            {
                Grupe.RemoveAt(a);
            }
            IzbornikRadSGrupama();
        }

        private void UrediGrupu ()
        {
            PrikaziGrupe();

            int i = Pomocno.UcitajInt("Odaberi redni broj grupe: ");
            var grupa = Grupe[i - 1];


            Console.WriteLine("1) Naziv");
            Console.WriteLine("2) Smjer");
            Console.WriteLine("3) Predavac");
            Console.WriteLine("4) Maksimalno polaznika");
            Console.WriteLine("5) Polaznici");
            Console.WriteLine("6) Pocetak nastave");
            Console.WriteLine("7) Uredi sve");
            Console.WriteLine("8) Povratak na izbornik grupe");

            switch (Pomocno.UcitajInt("\n" + "Odaberite stavku koju zelite promijeniti: "))
            {

                case 1:
                    string naziv = Pomocno.UcitajString("\n" + "_______________________________________" +
                                                       "\n" + "Stari naziv: " + grupa.Naziv +
                                                        "\n" + "Novi naziv: ");

                    bool potvrda = Pomocno.UcitajBool("\n" + "Promijeniti informacije grupe " +
                                                       "\n" +
                                                        "\n" + "Prijasnji unos: " + grupa.Naziv +
                                                         "\n" + "Novi unos: " + naziv +
                                                          "\n" + "Prihvati promjene: 1) DA / 2) NE | ");
                    if (potvrda)
                    {
                        grupa.Naziv = naziv;
                    }
                    break;

                case 2:

                    var smjer = PostaviSmjer();

                    
                    

                                  
                    potvrda = Pomocno.UcitajBool("\n" + "Promijeniti informacije grupe " +
                                                  "\n" +
                                                   "\n" + "Prijasnji unos: " + grupa.Smjer.Naziv +
                                                    "\n" + "Novi unos: " + smjer +
                                                     "\n" + "Prihvati promjene: 1) DA / 2) NE | ");

                    if (potvrda)
                    {
                        grupa.Smjer = smjer;
                    }
                    break;

                case 3:
                    Console.WriteLine("Prethodni predavac: " + grupa.Predavac.Ime + " " + grupa.Predavac.Prezime);
                    var predavac = PostaviPredavaca();


                    potvrda = Pomocno.UcitajBool("\n" + "Promijeniti informacije grupe " +
                                                  "\n" +
                                                   "\n" + "Prijasnji unos: " + grupa.Predavac.Ime + " " + grupa.Predavac.Prezime +
                                                    "\n" + "Novi unos: " + predavac +
                                                     "\n" + "Prihvati promjene: 1) DA / 2) NE | ");

                    if (potvrda)
                    {
                        grupa.Predavac = predavac;
                    }
                    break;

                case 4:

                    int maksimalnoPolaznika = Pomocno.UcitajInt("\n" + "_______________________________________" +
                                                                 "\n" + "Stari unos: " + grupa.MaksPolaznika +
                                                                  "\n" + "Novi unos: ");

                                      
                    potvrda = Pomocno.UcitajBool("\n" + "Promijeniti informacije gruope " +
                                                  "\n" +
                                                   "\n" + "Prijasnji unos: " + grupa.MaksPolaznika +
                                                    "\n" + "Novi unos: " + maksimalnoPolaznika +
                                                     "\n" + "Prihvati promjene: 1) DA / 2) NE | ");
                    if (potvrda)
                    {
                        grupa.MaksPolaznika = maksimalnoPolaznika;
                    }
                    break;

                case 5:

                    int b = 1;

                    Console.WriteLine("\n" + "Trenutni polaznici: " + "\n");
                    Console.WriteLine("------------------------------------------------------------------------------");


                    foreach (Polaznik polaznik in grupa.Polaznici)
                    {

                        Console.WriteLine("{0}. {1}", b++, polaznik);

                    }
                    Console.WriteLine("-------------------------------------------------------------------------------");

                  

                    var polaznici = PostaviPolaznike(grupa);
                                      

                    potvrda = Pomocno.UcitajBool("\n" + "Promijeniti informacije grupe " +
                                                  "\n" +
                                                   "\n" + "Prihvati promjene: 1) DA / 2) NE | ");
                    if (potvrda)
                    {
                       grupa.Polaznici = polaznici;
                    }
                    break;

                case 6:

                    DateTime dateTime = Pomocno.UcitajDatum("Novi datum pocetka: ");

                    potvrda = Pomocno.UcitajBool("\n" + "Promijeniti informacije grupe " +
                                                  "\n" + "Stari datum pocetka " + grupa.DatumPocetka +
                                                   "\n" + "Novi datum pocetka" + dateTime +
                                                    "\n" + "Prihvati promjene: 1) DA / 2) NE | ");
                    if (potvrda)
                    {
                        grupa.DatumPocetka = dateTime;
                    }



                    break;

                case 7:

                    naziv = Pomocno.UcitajString("\n" + "_______________________________________" +
                                                  "\n" + "Staro ime: " + grupa.Naziv +
                                                   "\n" + "Novo ime: ");

                    Console.WriteLine("\n" + "_______________________________________" +
                                       "\n" + "Stari smjer: " + grupa.Smjer +
                                        "\n" + "Novi smjer: ");
                    smjer = PostaviSmjer();


                    Console.WriteLine("\n" + "_______________________________________" +
                                       "\n" + "Stari predavac: " + grupa.Predavac +
                                        "\n" + "Novi predavac: ");
                    predavac = PostaviPredavaca();

                    maksimalnoPolaznika = Pomocno.UcitajInt("\n" + "_______________________________________" +
                                                                 "\n" + "Stari unos: " + grupa.MaksPolaznika +
                                                                  "\n" + "Novi unos: ");

                    Console.WriteLine("\n" + "_______________________________________" +
                                       "\n" + "Stari polaznici: " + grupa.Predavac +
                                        "\n" + "Novi polaznici: ");
                    polaznici = PostaviPolaznike(grupa);

                    dateTime = Pomocno.UcitajDatum("Novi datum pocetka: ");


                     potvrda = Pomocno.UcitajBool("\n" + "Prihvati izmjene: " + 
                                                       "\n" +   
                                                        "\n" + "Stari unos: " + grupa + 
                                                         "\n" + "Novi unos: " + smjer.Naziv + " || " + "Nova grupa: " + naziv + " || " + "Novi predavac: " + predavac.Ime + " " + predavac.Prezime + " || " +
                                                                "Maksimalno polaznika: " + maksimalnoPolaznika + " || " + "Novi datum pocetka: " + dateTime + 
                                                           "\n" + "Prihvati promjene 1) DA / 2) NE | ");

                    if (potvrda == true)
                    {
                        //  p.Sifra = sifra;
                        grupa.Naziv = naziv;
                        grupa.Predavac = predavac;
                        grupa.Smjer = smjer;
                        grupa.MaksPolaznika = maksimalnoPolaznika;
                        grupa.Polaznici = polaznici;
                        grupa.DatumPocetka = dateTime;


                    }

                    IzbornikRadSGrupama();
                    break;

                default:
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! " + "POGRESAN UNOS" + " !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!! " + " Provjerite ispravnost svoga unosa" + " !!!!!!!!!!!!!!!!!!!!!!!!");
                    break;
            }

            //int sifra = Pomocno.UcitajInt("\n" + "------------------------------------------------------------------------------" +
            //                                 "\n" + "Stara sifra: " + g.Sifra + "\n" + "Nova sifra: ");

            //while (ProvjeraSifreGrupe(Grupe, sifra) == true)
            //{
            //    UrediGrupu();
            //}
                  

            IzbornikRadSGrupama();
        }
                 

        private void DodajNovuGrupu ()
        {
            

            int sifra = Pomocno.UcitajInt("Unesi sifru grupe: ");
            Console.WriteLine();

            if (ProvjeraSifreGrupe(Grupe, sifra))
            {
                DodajNovuGrupu();
            }

            var s = PostaviSmjer();
            string naziv = Pomocno.UcitajString("Unesi naziv grupe: ");
            Console.WriteLine();
            var p = PostaviPredavaca();

            int maksPolaznika = Pomocno.UcitajInt("Maksimalan broj polaznika: ");
            Grupe.ForEach(x => { if(x.Polaznici.Count() > maksPolaznika)
                {

                    Console.WriteLine("!!!!!!!!!!!! Grupa je popunjena! Kreirajte novu grupu !!!!!!!!!!!!");
                    DodajNovuGrupu() ;

                }
                    
                    });

            

            Grupe.Add(new Grupa()
            {
                Sifra = sifra,
                Naziv = naziv,
                Predavac = p,
                Smjer = s,

                MaksPolaznika = maksPolaznika,
                Polaznici = PostaviPolaznike(),


                DatumPocetka = Pomocno.UcitajDatum("Unesi datum grupe u formatu dd.MM.yyyy.: ") // NAPOMENA!!!!! FORMAT RADI U SKLADU SA DATE & TIME POSTAVKAMA OPERATIVNOG SUSTAVA 


            }); ;

            IzbornikRadSGrupama();
        }

        private bool ProvjeraSifreGrupe (List<Grupa> grupe, int sifra)
        {
            foreach (Grupa grupa in Grupe)
            {
                if (grupa.Sifra.Equals(sifra))
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!! " + " Unesena sifra se koristi " + " !!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! " + " Unesite drugu sifru" + " !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    return true;

                }

            }
            return false;
        }

        private List<Polaznik> PostaviPolaznike ()
        {
            List<Polaznik> polaznici = new List<Polaznik>();


            while (Pomocno.UcitajBool("Zelite li dodati polaznike? 1) DA / 2) NE | "))
            {
             
                    polaznici.Add(PostaviPolaznika());
                           
            }
            return polaznici;
        }


        private List<Polaznik> PostaviPolaznike (Grupa grupa)
        {
            List<Polaznik> polaznici = new List<Polaznik>();

          

            while (Pomocno.UcitajBool("Zelite li dodati polaznike? 1) DA / 2) NE | "))
            {
                if(grupa.Polaznici.Count == 0)
                {
                    polaznici.Add(PostaviPolaznika());
                    return polaznici;
                } else
                {
                    polaznici = grupa.Polaznici;
                    
                    polaznici.Add(PostaviPolaznika());
              
                    return polaznici;
                }
                
                
            }
            return polaznici;
        }

        private Polaznik PostaviPolaznika ()
        {
           Izbornik.ObradaPolaznik.PrikaziPolaznike();

            int i = Pomocno.UcitajRasponBrojeva("\n" + "Odaberi redni broj polaznika: ", 0,Izbornik.ObradaPolaznik.Polaznici.Count());

            // ako polaznik postoji, odbij unos

            return Izbornik.ObradaPolaznik.Polaznici[i - 1];
        }

        private Smjer PostaviSmjer ()
        {
            Izbornik.ObradaSmjer.PrikaziSmjerove();
            int i = Pomocno.UcitajInt("\n" + "Odaberi redni broj smjera: ");
            return Izbornik.ObradaSmjer.Smjerovi[i - 1];
        }

        private Predavac PostaviPredavaca ()
        {
            Izbornik.ObradaPredavac.PrikaziPredavace();

            int i = Pomocno.UcitajRasponBrojeva("\n" + "Odaberi redni broj predavaca: ", 0, Izbornik.ObradaPredavac.Predavaci.Count());
            return Izbornik.ObradaPredavac.Predavaci[i - 1];
        }

        private void PrikaziGrupe ()
        {
            var i = 0;
            Grupe.ForEach(g => { Console.WriteLine(++i + ". " + g); });


        }
        private void PrikaziSvePolaznikeOdabraneGrupe ()
        {
            PrikaziGrupe();
            int b = 1;
            int i = Pomocno.UcitajInt("Odaberi redni broj grupe: ");
            var g = Grupe[i - 1];

            Console.WriteLine("-----------------------------------------------------------------");

            foreach (Polaznik polaznik in g.Polaznici)
            {
                Console.WriteLine("{0}. {1}", b++, polaznik);

            }
            Console.WriteLine("-----------------------------------------------------------------");



        }

        private void UcitajUkupanBrojPolaznika (List<Grupa> Grupe)
        {
            int a = 0;
            int b = 0;

            var p = Izbornik.ObradaPolaznik.Polaznici;

            Console.WriteLine();
            Grupe.ForEach(Grupa => { Console.WriteLine("Trenutno nastavu pohada " + Grupa.Polaznici.Count() + " polaznika u " + ++a +". " + " grupi"); });

            Izbornik.ObradaPolaznik.Polaznici.ForEach(Polaznici => { ++b; });



            Console.WriteLine("\n"+ "Sveukupno polaznika na svim grupama: " + b);



            IzbornikRadSGrupama();

        }

        private void ProsjecanBrojPolaznikaUGrupama(List<Grupa> grupa)
        {
            int a = 0;
            int b = 0;

            int aritmetickiProsjek = 0;

            Izbornik.ObradaPolaznik.Polaznici.ForEach(Polaznici => { ++a; });
            Grupe.ForEach(Grupe => {  ++b; });
            Console.WriteLine("Prosjek polaznika po svim grupama: " + (aritmetickiProsjek = a /b));

            IzbornikRadSGrupama();
        }

        private void IznosPrihodaPoSmjerovima (List<Grupa> grupe)
        {

            Izbornik.ObradaSmjer.PrikaziSmjerove();

            int odabirSmjera = Pomocno.UcitajInt("\n" + "Odaberi smjer za prikaz statistike: ");

            var smjer = Izbornik.ObradaSmjer.Smjerovi[odabirSmjera - 1];

            float priljeviSmjera = smjer.Cijena + smjer.Upisnina;

            float a = 0;

            foreach (Grupa g in grupe)
            {
                if (g.Smjer.Naziv.Contains(smjer.Naziv))
                {
                  a += g.Polaznici.Count(); 
                }
            }
                            

            Console.WriteLine("Prihod smjera: " + priljeviSmjera * a);
                                  
            if(Pomocno.UcitajBool("Zelite li nastaviti pregledavati ovaj izbornik?" + "\n" + "1) DA / 2) NE | "))
            {
                IznosPrihodaPoSmjerovima(grupe);
            }
            IzbornikRadSGrupama();

        }
        private void ProsjecanIznosPrihodaPoPolazniku ()
        {
            int a = 0;
            int b = 0;
            float priljeviSmjera = 0;
            float[] niz = new float[b];


            Izbornik.ObradaPolaznik.Polaznici.ForEach(Polaznici => { ++a; });
            
            

            for (int i = 0; i < Izbornik.ObradaSmjer.Smjerovi.Count; i++) 
            {
                var pS = Izbornik.ObradaSmjer.Smjerovi[i];
                b++;

                foreach (Grupa g in Grupe)
                {
                    if (g.Smjer.Naziv.Contains(pS.Naziv))
                    {
                        priljeviSmjera = pS.Upisnina + pS.Cijena;
                        niz[i] = priljeviSmjera;

                    }
                    Console.WriteLine(priljeviSmjera);
                }


               
               
                          
            
            }

            float prihod = priljeviSmjera * a;

            IzbornikRadSGrupama();
        }



        //private void TestniPodaci ()
        //{
        //    DateTime obj;

        //    Grupe.Add(new Grupa()
        //    {
        //        Sifra = 1,
        //        Naziv = "WP-2",
        //        Predavac = Predavaci[1],
        //        Smjer = Smjerovi[1],
        //        MaksPolaznika = 25,
        //        Polaznici = Polaznici[1],  

        //        DatumPocetka = DateTime.Today,




        //    });
        //}

    }
}
