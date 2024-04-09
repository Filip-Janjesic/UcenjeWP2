using AutoMapper;
using EdunovaAPP.Models;

namespace EdunovaAPP.Mappers
{
    public class MappingPolaznik : Mapping<Polaznik, PolaznikDTORead, PolaznikDTOInsertUpdate>
    {

        public MappingPolaznik()
        {
            MapperMapReadToDTO = new Mapper(
            new MapperConfiguration(c =>
            {
                c.CreateMap<Polaznik, PolaznikDTORead>()
                .ConstructUsing(entitet =>
                 new PolaznikDTORead(
                    entitet.Sifra,
                    entitet.Ime,
                    entitet.Prezime,
                    entitet.Email,
                    entitet.Oib,
                    entitet.BrojUgovora,
                    PutanjaDatoteke(entitet)));
            })
            );

            MapperMapInsertUpdateToDTO = new Mapper(
              new MapperConfiguration(c =>
              {
                  c.CreateMap<Polaznik, PolaznikDTOInsertUpdate>()
               .ConstructUsing(entitet =>
                new PolaznikDTOInsertUpdate(
                   entitet.Ime,
                   entitet.Prezime,
                   entitet.Email,
                   entitet.Oib,
                   entitet.BrojUgovora,
                   PutanjaDatoteke(entitet)));
              })
              );
        }


        private static string PutanjaDatoteke(Polaznik e)
        {
            try
            {
                var ds = Path.DirectorySeparatorChar;
                string slika = Path.Combine(Directory.GetCurrentDirectory()
                    + ds + "wwwroot" + ds + "slike" + ds + "polaznici" + ds + e.Sifra + ".png");
                return File.Exists(slika) ? "/slike/polaznici/" + e.Sifra + ".png" : null;
            }
            catch
            {
                return null;
            }

        }



    }
}
