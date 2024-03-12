using EdunovaAPP.Mappers;
using EdunovaAPP.Models;

namespace EdunovaAPP.Extensions
{
    public static class MappingPredavac
    {

        public static List<PredavacDTORead> MapPredavacReadList(this List<Predavac> lista)
        {
            var mapper = PredavacMapper.InicijalizirajReadToDTO();
            var vrati = new List<PredavacDTORead>();
            lista.ForEach(e => {
                vrati.Add(mapper.Map<PredavacDTORead>(e));
            });
            return vrati;
        }

        public static PredavacDTORead MapPredavacReadToDTO(this Predavac entitet)
        {
            var mapper = PredavacMapper.InicijalizirajReadToDTO();
            return mapper.Map<PredavacDTORead>(entitet);
        }

        public static PredavacDTOInsertUpdate MapPredavacInsertUpdatedToDTO(this Predavac entitet)
        {
            var mapper = PredavacMapper.InicijalizirajInsertUpdateToDTO();
            return mapper.Map<PredavacDTOInsertUpdate>(entitet);
        }

        public static Predavac MapPredavacInsertUpdateFromDTO(this PredavacDTOInsertUpdate dto, Predavac entitet)
        {
            entitet.Ime = dto.ime;
            entitet.Prezime = dto.prezime;
            entitet.Email= dto.email;
            entitet.Oib= dto.oib;
            entitet.Iban = dto.iban;
            return entitet;
        }

    }
}
