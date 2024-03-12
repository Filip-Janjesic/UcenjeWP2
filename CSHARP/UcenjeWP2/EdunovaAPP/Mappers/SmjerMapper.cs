using AutoMapper;
using EdunovaAPP.Models;

namespace EdunovaAPP.Mappers
{
    public class SmjerMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Smjer, SmjerDTORead>();
                })
                );
        }

        public static Mapper InicijalizirajReadFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<SmjerDTORead, Smjer>();
                })
                );
        }

        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Smjer, SmjerDTOInsertUpdate>();
                })
                );
        }

    }
}
