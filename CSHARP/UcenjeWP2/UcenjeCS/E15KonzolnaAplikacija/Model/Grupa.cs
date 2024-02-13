namespace UcenjeCS.E15KonzolnaAplikacija.Model
{
    internal class Grupa: Entitet
    {
        public string Naziv { get; set; }
        public Smjer Smjer { get; set; }
        public DateTime DatumPocetka { get; set; }
        public List<Polaznik> Polaznici { get; set; }
    }
}
