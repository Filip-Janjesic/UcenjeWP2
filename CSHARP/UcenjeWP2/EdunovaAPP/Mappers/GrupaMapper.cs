using AutoMapper;
using EdunovaAPP.Models;

namespace EdunovaAPP.Mappers
{
    public class GrupaMapper
    {
        /*
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Grupa, GrupaDTORead>()
                    .ForMember(dto => dto.smjer, entitet => entitet.MapFrom(src => src.Smjer!.Naziv))
                    .ForMember(dto => dto.predavac, entitet => entitet.MapFrom(src => src.Predavac!.Ime
                    + " " + src.Predavac!.Prezime))
                    .ForMember(dto => dto.brojpolaznika, entitet => entitet.MapFrom(src => src.Polaznici!.Count()));
                })
                );
        }
        */
        
        /*
        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Grupa, GrupaDTOInsertUpdate>()
                    .ForMember(dto => dto.smjer, entitet => entitet.MapFrom(src => src.Smjer!.Naziv))
                    .ForMember(dto => dto.predavac, entitet => entitet.MapFrom(src => src.Predavac!.Ime
                    + " " + src.Predavac!.Prezime));
                })
                );
        }
        */

    }
}
