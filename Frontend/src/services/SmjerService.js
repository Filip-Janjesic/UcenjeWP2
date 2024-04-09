import  { httpService, obradiGresku, obradiUspjeh, obradiUspjehBrisanje,get,obrisi,dodaj,getBySifra,promjeni } from "./httpService";


async function getOznake(sifra){
    return await httpService.get('/Smjer/Oznake/' + sifra).then((res)=>{return obradiUspjeh(res);}).catch((e)=>{ return obradiGresku(e);});
  }

  async function obrisiOznaku(sifra){
    return await httpService.delete('/Smjer/ObrisiOznaku/' + sifra)
        .then((res)=>{
            return obradiUspjehBrisanje(res);
        }).catch((e)=>{
            return obradiGresku(e);
        });
}

async function dodajOznaku(smjerOznaka) {
    return await httpService.post('/Smjer/DodajOznaku/',smjerOznaka).then((res)=>{return obradiUspjeh(res);}).catch((e)=>{ return obradiGresku(e);});
  }



export default{
    get,
    obrisi,
    dodaj,
    promjeni,
    getBySifra,
    getOznake,
    obrisiOznaku,
    dodajOznaku
};