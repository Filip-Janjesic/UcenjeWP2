import { useEffect, useState } from 'react';
import { Container, Form } from 'react-bootstrap';
import { useNavigate, useParams } from 'react-router-dom';
import Service from '../../services/PredavacService';
import { RoutesNames } from '../../constants';
import useError from '../../hooks/useError';
import InputText from '../../components/InputText';
import Akcije from '../../components/Akcije';

export default function PredavaciPromjeni() {
  const [predavac, setPredavac] = useState({});

  const routeParams = useParams();
  const navigate = useNavigate();

  const { prikaziError } = useError();


  async function dohvatiPredavac() {
    const odgovor = await Service.getBySifra('Predavac',routeParams.sifra);
    if(!odgovor.ok){
      prikaziError(odgovor.podaci);
      return;
    }
    setPredavac(odgovor.podaci);
  }

  async function promjeniPredavac(predavac) {
    const odgovor = await Service.promjeni('Predavac',routeParams.sifra, predavac);
    if(odgovor.ok){
      navigate(RoutesNames.PREDAVACI_PREGLED);
      return;
    }
    prikaziError(odgovor.podaci);
  }

  useEffect(() => {
    dohvatiPredavac();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  
  function handleSubmit(e) {
    e.preventDefault();
    const podaci = new FormData(e.target);
    promjeniPredavac({
      ime: podaci.get('ime'),
      prezime: podaci.get('prezime'),
      oib: podaci.get('oib'),
      email: podaci.get('email'),
      iban: podaci.get('iban')
    });
  }

  return (
    <Container>
      <Form onSubmit={handleSubmit}>
        <InputText atribut='ime' vrijednost={predavac.ime} />
        <InputText atribut='prezime' vrijednost={predavac.prezime} />
        <InputText atribut='oib' vrijednost={predavac.oib} />
        <InputText atribut='email' vrijednost={predavac.email} />
        <InputText atribut='iban' vrijednost={predavac.iban} />
        <Akcije odustani={RoutesNames.PREDAVACI_PREGLED} akcija='Promjeni predavača' />
      </Form>
    </Container>
  );
}
