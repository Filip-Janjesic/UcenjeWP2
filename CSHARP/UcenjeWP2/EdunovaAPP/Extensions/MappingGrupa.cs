using AutoMapper;
using EdunovaAPP.Mappers;
using EdunovaAPP.Models;

namespace EdunovaAPP.Extensions
{
    public static class MappingGrupa
    {

        public static List<GrupaDTORead> MapGrupaReadList(this List<Grupa> lista)
        {
            /*
            var mapper = GrupaMapper.InicijalizirajReadToDTO();
            var vrati = new List<GrupaDTORead>();
            lista.ForEach(e => {
                vrati.Add(mapper.Map<GrupaDTORead>(e));
            });
            return vrati;
          */
           
            var vrati = new List<GrupaDTORead>();
            int sifra, brojpolaznika=0;
            int? maksimalnopolaznika=0;
            string naziv,smjer,predavac;
            DateTime? datumpocetka = DateTime.Now;

            lista.ForEach(e => {
                sifra = e.Sifra;
                naziv = e.Naziv;
                smjer = null;
                if(e.Smjer!=null)
                {
                    smjer = e.Smjer.Naziv;
                }
                predavac = null;
                if (e.Predavac != null )
                {
                    predavac = e.Predavac.Ime + " " + e.Predavac.Prezime;
                }
                if (e.Polaznici != null)
                {
                    brojpolaznika = e.Polaznici.Count();
                }
                datumpocetka = e.DatumPocetka;
                maksimalnopolaznika = e.MaksimalnoPolaznika;
                vrati.Add(new GrupaDTORead(sifra,naziv,smjer,predavac,brojpolaznika,datumpocetka,maksimalnopolaznika));
            });
            return vrati;
         
        }

        public static GrupaDTORead MapGrupaReadToDTO(this Grupa e)
        {
            int sifra, brojpolaznika = 0;
            int? maksimalnopolaznika = 0;
            string naziv, smjer, predavac;
            DateTime? datumpocetka = DateTime.Now;

            sifra = e.Sifra;
            naziv = e.Naziv;
            smjer = null;
            if (e.Smjer != null)
            {
                smjer = e.Smjer.Naziv;
            }
            predavac = null;
            if (e.Predavac != null)
            {
                predavac = e.Predavac.Ime + " " + e.Predavac.Prezime;
            }
            if (e.Polaznici != null)
            {
                brojpolaznika = e.Polaznici.Count();
            }
            datumpocetka = e.DatumPocetka;
            maksimalnopolaznika = e.MaksimalnoPolaznika;
            
            return new GrupaDTORead(sifra, naziv, smjer, predavac, brojpolaznika, datumpocetka, maksimalnopolaznika);

        }
        
        public static GrupaDTOInsertUpdate MapGrupaInsertUpdatedToDTO(this Grupa e)
        {

            int smjer=0;
            int predavac = 0;
            int? maksimalnopolaznika = 0;
            string naziv;
            DateTime? datumpocetka = DateTime.Now;

            
            naziv = e.Naziv;
            maksimalnopolaznika = e.MaksimalnoPolaznika;
            if (e.Smjer != null)
            {
                smjer = e.Smjer.Sifra;
            }
            
            if (e.Predavac != null)
            {
                predavac = e.Predavac.Sifra;
            }
            
            datumpocetka = e.DatumPocetka;

            return new GrupaDTOInsertUpdate(naziv, smjer, predavac, datumpocetka, maksimalnopolaznika);



        }


        public static Grupa MapGrupaInsertUpdateFromDTO(this GrupaDTOInsertUpdate dto, Grupa entitet)
        {
            entitet.Naziv = dto.naziv;
            entitet.MaksimalnoPolaznika = dto.maksimalnopolaznika;
            entitet.DatumPocetka = dto.datumpocetka;
            return entitet;
        }

    }
}
