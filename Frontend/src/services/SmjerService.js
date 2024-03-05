import { App } from "../constants"
import { httpService } from "./httpService";

async function getSmjerovi(){
    return await httpService.get('/Smjer')
    .then((res)=>{
        if(App.DEV) console.table(res.data);

        return res;
    }).catch((e)=>{
        console.log(e);
    });
}

async function obrisiSmjer(sifra){
    return await httpService.delete('/Smjer/' + sifra)
    .then((res)=>{
        return {ok: true, poruka: res};
    }).catch((e)=>{
        console.log(e);
    });
}

async function dodajSmjer(smjer){
    const odgovor = await httpService.post('/Smjer',smjer)
    .then(()=>{
        return {ok: true, poruka: 'Uspješno dodano'}
    })
    .catch((e)=>{
        //console.log(e.response.data.errors.Naziv[0]);
        return {ok: false, poruka: e.response.data.errors.Naziv[0]}
    });
    return odgovor;
}




export default{
    getSmjerovi,
    obrisiSmjer,
    dodajSmjer
};