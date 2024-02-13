namespace UcenjeCS.E15KonzolnaAplikacija.Model
{
    internal class Polaznik : Entitet
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Oib { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
