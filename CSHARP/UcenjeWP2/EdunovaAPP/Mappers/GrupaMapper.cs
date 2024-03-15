using AutoMapper;
using EdunovaAPP.Models;

namespace EdunovaAPP.Mappers
{
    public class GrupaMapper
    {
        
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(    
            new MapperConfiguration(c =>
            {
                c.CreateMap<Grupa, GrupaDTORead>()
                .ConstructUsing(entitet => 
                 new GrupaDTORead(
                    entitet.Sifra,
                    entitet.Naziv,
                    entitet.Smjer == null ? "" : entitet.Smjer.Naziv,
                    entitet.Predavac == null ? "" :(entitet.Predavac.Ime
                        + " " + entitet.Predavac.Prezime).Trim(),
                    entitet.Polaznici!.Count(),
                    entitet.DatumPocetka,
                    entitet.MaksimalnoPolaznika == null ? 0 : entitet.MaksimalnoPolaznika));
            })
            );
        }
        
        
      
        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
             new MapperConfiguration(c =>
             {
                 c.CreateMap<Grupa, GrupaDTOInsertUpdate>()
                 .ConstructUsing(entitet =>
                  new GrupaDTOInsertUpdate(
                     entitet.Naziv,
                     entitet.Smjer == null ? null : entitet.Smjer.Sifra,
                     entitet.Predavac == null ? null : entitet.Predavac.Sifra,
                     entitet.DatumPocetka,
                     entitet.MaksimalnoPolaznika))
                 ;
             })
             );
        }
        

    }
}
