import { Container, Form } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import Service from '../../services/PredavacService';
import { RoutesNames } from '../../constants';
import useError from '../../hooks/useError';
import InputText from '../../components/InputText';
import Akcije from '../../components/Akcije';


export default function PredavaciDodaj() {
  const navigate = useNavigate();
  const { prikaziError } = useError();


  async function dodajPredavac(Predavac) {
    const odgovor = await Service.dodaj('Predavac',Predavac);
    if(odgovor.ok){
      navigate(RoutesNames.PREDAVACI_PREGLED);
      return
    }
    prikaziError(odgovor.podaci);
  }

  function handleSubmit(e) {
    e.preventDefault();

    const podaci = new FormData(e.target);


    dodajPredavac({
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
        <InputText atribut='ime' vrijednost='' />
        <InputText atribut='prezime' vrijednost='' />
        <InputText atribut='oib' vrijednost='' />
        <InputText atribut='email' vrijednost='' />
        <InputText atribut='iban' vrijednost='' />
        <Akcije odustani={RoutesNames.PREDAVACI_PREGLED} akcija='Dodaj predavača' />       
      </Form>
    </Container>
  );
}
