import { Container, Form } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import Service from '../../services/PolaznikService';
import { RoutesNames } from '../../constants';
import useError from '../../hooks/useError';
import InputText from '../../components/InputText';
import Akcije from '../../components/Akcije';
import useLoading from '../../hooks/useLoading';


export default function PolazniciDodaj() {
  const navigate = useNavigate();
  const { prikaziError } = useError();
  const { showLoading, hideLoading } = useLoading();


  async function dodajPolaznik(Polaznik) {
    showLoading();
    const odgovor = await Service.dodaj('Polaznik',Polaznik);
    if(odgovor.ok){
      hideLoading();
      navigate(RoutesNames.POLAZNICI_PREGLED);
      return
    }
    prikaziError(odgovor.podaci);
    hideLoading();
  }

  function handleSubmit(e) {
    e.preventDefault();
    const podaci = new FormData(e.target);
    dodajPolaznik({
      ime: podaci.get('ime'),
      prezime: podaci.get('prezime'),
      oib: podaci.get('oib'),
      email: podaci.get('email'),
      brojugovora: podaci.get('brojugovora'),
      slika: ''
    });
  }

  return (
    <Container className='mt-4'>
      <Form onSubmit={handleSubmit}>
        <InputText atribut='ime' vrijednost='' />
        <InputText atribut='prezime' vrijednost='' />
        <InputText atribut='oib' vrijednost='' />
        <InputText atribut='email' vrijednost='' />
        <InputText atribut='brojugovora' vrijednost='' />
        <Akcije odustani={RoutesNames.POLAZNICI_PREGLED} akcija='Dodaj polaznika' />  
      </Form>
    </Container>
  );
}
