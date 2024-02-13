using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UcenjeCS.E15KonzolnaAplikacija.Model;

namespace UcenjeCS.E15KonzolnaAplikacija
{
    internal class Program
    {
        private List<Smjer> Smjerovi;
        public Program()
        {
            Smjerovi= new List<Smjer>();
            PozdravnaPoruka();
            Izbornik();
        }

        private void Izbornik()
        {
            Console.WriteLine("Izbornik");
            Console.WriteLine("1. Rad s smjerovima");
            Console.WriteLine("2. Rad s predavačim");
            Console.WriteLine("3. Rad s polaznicima");
            Console.WriteLine("4. Rad s grupama");
            Console.WriteLine("5. Izlaz iz programa");
            OdabirStavkePocetnogIzbornika();
        }

        private void OdabirStavkePocetnogIzbornika()
        {
            //var Izbor = Pomocno.UcitajInt("Unesi izbor: ");
            switch (Pomocno.UcitajInt("Unesi izbor: "))
            {
                case 1:
                    Console.WriteLine("Rad sa smjerovima");
                    IzbornikRadSaSmjerovima();
                    break;
                case 2:
                    Console.WriteLine("Rad s predavačima");
                    break;
                case 3:
                    Console.WriteLine("Rad s polaznicima");
                    break;
                case 4:
                    Console.WriteLine("Rad s polaznicima");
                    break;
                case 5:
                    Console.WriteLine("Izlaz iz programa");
                    break;
                default:
                    Console.WriteLine("Krivi odabir");
                    Izbornik();
                    break;

            }
        }

        private void IzbornikRadSaSmjerovima()
        {
            Console.WriteLine("1. Prikaži sve smjerove");
            Console.WriteLine("2. Dodaj smjer");
            Console.WriteLine("3. Uredi smjer");
            Console.WriteLine("4. Izbriši smjer");
            Console.WriteLine("5. Povratak na glavni izbornik");
            OdabirStavkeIzbornikSmjera();
        }

        private void PozdravnaPoruka()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("* EDUNOVA KONZOLNA APLIKACIJA V1 *");
            Console.WriteLine("**********************************");
        }

        private void OdabirStavkeIzbornikSmjera()
        {
            switch (Pomocno.UcitajInt("Odaberi stavku izbornika: "))
            {
                case 1:
                    Console.WriteLine("Prikaži sve smjerove");
                    PrikaziSveSmjerove();
                    IzbornikRadSaSmjerovima();
                    break;
                case 2:
                    Console.WriteLine("Dodaj smjer");
                    DodajNoviSmjer();
                    break;
                case 3:
                    Console.WriteLine("Uredi smjer");
                    UrediSmjer();
                    break;
                case 4:
                    Console.WriteLine("Izbriši smjer");
                    IzbrisiSmjer();
                    break;
                case 5:
                    Izbornik();
                    break;
                default:
                    Console.WriteLine("Krivi odabir");
                    IzbornikRadSaSmjerovima();
                    break;
            }
        }

        private void IzbrisiSmjer()
        {
            PrikaziSveSmjerove();
            Smjerovi.RemoveAt(Pomocno.UcitajInt("Odaberi smjer za brisanje: ")-1);
            IzbornikRadSaSmjerovima();
        }

        private void UrediSmjer()
        {
            PrikaziSveSmjerove();
            var s = Smjerovi[Pomocno.UcitajInt("Odaberi smjer za prmjenu: ") - 1];
            s.Sifra = Pomocno.UcitajInt(s.Sifra +  ", Unesi promjenjenu šifru: ");
            s.Naziv = Pomocno.UcitajString(s.Naziv +", Unesi promjenjeni naziv: ");
            // promjeniti ostale vrijednosti
            IzbornikRadSaSmjerovima();

        }

        private void PrikaziSveSmjerove()
        {
            var i = 0;
            Smjerovi.ForEach(s => {
                Console.WriteLine(++i + ". " + s);
            });
            Console.WriteLine("*********************");

        }

        private void DodajNoviSmjer()
        {
            Smjerovi.Add(new Smjer() { 
            Sifra = Pomocno.UcitajInt("Unesi šifru smjera: "),
                Naziv = Pomocno.UcitajString("Unesi naziv smjera: ")
            });
            IzbornikRadSaSmjerovima();
        }
    }
}
