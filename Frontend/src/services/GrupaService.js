import { httpService, obradiGresku, obradiUspjeh, get,obrisi,dodaj,getBySifra,promjeni  } from "./httpService";

async function getPolaznici(naziv,sifra){
  return await httpService.get('/' + naziv + '/Polaznici/' + sifra).then((res)=>{return obradiUspjeh(res);}).catch((e)=>{ return obradiGresku(e);});
}
async function dodajPolaznika(naziv,grupa, polaznik) {
  return await httpService.post('/' + naziv + '/' + grupa + '/dodaj/' + polaznik).then((res)=>{return obradiUspjeh(res);}).catch((e)=>{ return obradiGresku(e);});
}
async function obrisiPolaznika(naziv,grupa, polaznik) {
  return await httpService.delete('/'+naziv+'/' + grupa + '/obrisi/' + polaznik).then((res)=>{return obradiUspjeh(res);}).catch((e)=>{ return obradiGresku(e);});
}

export default{
    get,
    obrisi,
    dodaj,
    getBySifra,
    promjeni,
    getPolaznici,
    dodajPolaznika,
    obrisiPolaznika
};