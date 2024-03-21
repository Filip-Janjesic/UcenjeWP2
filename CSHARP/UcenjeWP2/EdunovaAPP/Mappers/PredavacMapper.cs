using AutoMapper;
using EdunovaAPP.Models;

namespace EdunovaAPP.Mappers
{
    
    public class PredavacMapper
    {
      
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
            new MapperConfiguration(c =>
            {
                c.CreateMap<Predavac, PredavacDTORead>()
                .ConstructUsing(entitet =>
                 new PredavacDTORead(
                    entitet.Sifra,
                    entitet.Ime,
                    entitet.Prezime,
                    entitet.Email,
                    entitet.Oib,
                    entitet.Iban,
                    PutanjaDatoteke(entitet)));
            })
            );
        }

        private static string PutanjaDatoteke( Predavac e )
        {
            var ds = Path.DirectorySeparatorChar;
            string dir = Path.Combine(Directory.GetCurrentDirectory()
                + ds + "wwwroot" + ds + "datoteke" + ds + "predavaci" + ds);
            DirectoryInfo d = new DirectoryInfo(dir);
            FileInfo[] Files = d.GetFiles(e.Sifra + "_*"); // dohvati sve koji počinju s šifra_ 
            return Files != null && Files.Length > 0 ? "/datoteke/predavaci/" + Files[0].Name : null;
        }

        public static Mapper InicijalizirajReadFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<PredavacDTORead, Predavac>();
                })
                );
        }

        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Predavac, PredavacDTOInsertUpdate>();
                })
                );
        }

    }
}
