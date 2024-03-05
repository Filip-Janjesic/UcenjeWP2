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
        console.log(e.response.data.errors);
        return {ok: false, poruka: 'Greška'}
    });
    return odgovor;
}

async function promjeniSmjer(sifra,smjer){
    const odgovor = await httpService.put('/Smjer/'+sifra,smjer)
    .then(()=>{
        return {ok: true, poruka: 'Uspješno promjnjeno'}
    })
    .catch((e)=>{
        console.log(e.response.data.errors);
        return {ok: false, poruka: 'Greška'}
    });
    return odgovor;
}

async function getBySifra(sifra){
    return await httpService.get('/Smjer/' + sifra)
    .then((res)=>{
        if(App.DEV) console.table(res.data);

        return res;
    }).catch((e)=>{
        console.log(e);
        return {poruka: e}
    });
}



export default{
    getSmjerovi,
    obrisiSmjer,
    dodajSmjer,
    promjeniSmjer,
    getBySifra
};