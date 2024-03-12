using AutoMapper;
using EdunovaAPP.Models;

namespace EdunovaAPP.Mappers
{
    public class PolaznikMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Polaznik, PolaznikDTORead>();
                })
                );
        }

        public static Mapper InicijalizirajReadFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<PolaznikDTORead, Polaznik>();
                })
                );
        }

        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Polaznik, PolaznikDTOInsertUpdate>();
                })
                );
        }

    }
}
