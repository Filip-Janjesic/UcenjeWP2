using EdunovaAPP.Mappers;
using EdunovaAPP.Models;

namespace EdunovaAPP.Extensions
{
    public static class Mapping
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

        public static Smjer MapSmjerInsertUpdateFromDTO(this SmjerDTOInsertUpdate entitet)
        {
            var mapper = SmjerMapper.InicijalizirajInsertUpdateFromDTO();
            return mapper.Map<Smjer>(entitet);
        }

    }
}
