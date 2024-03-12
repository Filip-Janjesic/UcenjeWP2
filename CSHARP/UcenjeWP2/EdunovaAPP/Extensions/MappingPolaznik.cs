using EdunovaAPP.Mappers;
using EdunovaAPP.Models;

namespace EdunovaAPP.Extensions
{
    public static class MappingPolaznik
    {

        public static List<PolaznikDTORead> MapPolaznikReadList(this List<Polaznik> lista)
        {
            var mapper = PolaznikMapper.InicijalizirajReadToDTO();
            var vrati = new List<PolaznikDTORead>();
            lista.ForEach(e => {
                vrati.Add(mapper.Map<PolaznikDTORead>(e));
            });
            return vrati;
        }

        public static PolaznikDTORead MapPolaznikReadToDTO(this Polaznik entitet)
        {
            var mapper = PolaznikMapper.InicijalizirajReadToDTO();
            return mapper.Map<PolaznikDTORead>(entitet);
        }

        public static PolaznikDTOInsertUpdate MapPolaznikInsertUpdatedToDTO(this Polaznik entitet)
        {
            var mapper = PolaznikMapper.InicijalizirajInsertUpdateToDTO();
            return mapper.Map<PolaznikDTOInsertUpdate>(entitet);
        }

        public static Polaznik MapPolaznikInsertUpdateFromDTO(this PolaznikDTOInsertUpdate dto, Polaznik entitet)
        {
            entitet.Ime = dto.ime;
            entitet.Prezime = dto.prezime;
            entitet.Email= dto.email;
            entitet.Oib= dto.oib;
            entitet.BrojUgovora = dto.brojugovora;
            return entitet;
        }

    }
}
