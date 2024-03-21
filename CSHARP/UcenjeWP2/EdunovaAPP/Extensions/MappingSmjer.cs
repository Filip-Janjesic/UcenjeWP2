using EdunovaAPP.Mappers;
using EdunovaAPP.Models;

namespace EdunovaAPP.Extensions
{
    public static class MappingSmjer
    {

        public static List<SmjerDTORead> MapSmjerReadList(this List<Smjer> lista)
        {
            var mapper = SmjerMapper.InicijalizirajReadToDTO();
            var vrati = new List<SmjerDTORead>();
            lista.ForEach(e => {
                vrati.Add(mapper.Map<SmjerDTORead>(e));
            });
            return vrati;
        }

        public static SmjerDTORead MapSmjerReadToDTO(this Smjer entitet)
        {
            var mapper = SmjerMapper.InicijalizirajReadToDTO();
            return mapper.Map<SmjerDTORead>(entitet);
        }

        public static SmjerDTOInsertUpdate MapSmjerInsertUpdatedToDTO(this Smjer entitet)
        {
            var mapper = SmjerMapper.InicijalizirajInsertUpdateToDTO();
            return mapper.Map<SmjerDTOInsertUpdate>(entitet);
        }

        public static Smjer MapSmjerInsertUpdateFromDTO(this SmjerDTOInsertUpdate dto, Smjer entitet)
        {
            entitet.Naziv = dto.naziv;
            entitet.Trajanje = dto.trajanje;
            entitet.Cijena= dto.cijena;
            entitet.Upisnina= dto.upisnina;
            entitet.Verificiran= dto.verificiran;
            return entitet;
        }

    }
}
