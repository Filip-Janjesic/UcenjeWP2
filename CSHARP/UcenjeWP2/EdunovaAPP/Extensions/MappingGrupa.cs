using AutoMapper;
using EdunovaAPP.Mappers;
using EdunovaAPP.Models;

namespace EdunovaAPP.Extensions
{
    public static class MappingGrupa
    {

        public static List<GrupaDTORead> MapGrupaReadList(this List<Grupa> lista)
        {
            var mapper = GrupaMapper.InicijalizirajReadToDTO();
            var vrati = new List<GrupaDTORead>();
            lista.ForEach(e => { 
                    vrati.Add(mapper.Map<GrupaDTORead>(e));
            });
            return vrati;
        }

        public static GrupaDTORead MapGrupaReadToDTO(this Grupa e)
        {
            var mapper = GrupaMapper.InicijalizirajReadToDTO();
            return mapper.Map<GrupaDTORead>(e);

        }
        
        public static GrupaDTOInsertUpdate MapGrupaInsertUpdatedToDTO(this Grupa e)
        {

            var mapper = GrupaMapper.InicijalizirajInsertUpdateToDTO();
            return mapper.Map<GrupaDTOInsertUpdate>(e);


        }


        public static Grupa MapGrupaInsertUpdateFromDTO(this GrupaDTOInsertUpdate dto, Grupa entitet)
        {
            entitet.Naziv = dto.naziv;
            entitet.MaksimalnoPolaznika = dto.maksimalnopolaznika;
            entitet.DatumPocetka = dto.datumpocetka;
            return entitet;
        }

    }
}
