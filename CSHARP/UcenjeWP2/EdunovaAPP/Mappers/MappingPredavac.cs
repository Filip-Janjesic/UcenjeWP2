using AutoMapper;
using EdunovaAPP.Models;

namespace EdunovaAPP.Mappers
{
    public class MappingPredavac : Mapping<Predavac, PredavacDTORead, PredavacDTOInsertUpdate>
    {

        public MappingPredavac()
        {
            MapperMapReadToDTO = new Mapper(
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


        private static string PutanjaDatoteke(Predavac e)
        {
            try
            {
                var ds = Path.DirectorySeparatorChar;
                string dir = Path.Combine(Directory.GetCurrentDirectory()
                    + ds + "wwwroot" + ds + "datoteke" + ds + "predavaci" + ds);
                DirectoryInfo d = new DirectoryInfo(dir);
                FileInfo[] Files = d.GetFiles(e.Sifra + "_*"); // dohvati sve koji počinju s šifra_ 
                return Files != null && Files.Length > 0 ? "/datoteke/predavaci/" + Files[0].Name : null;
            }
            catch
            {
                return null;
            }

        }



    }
}
