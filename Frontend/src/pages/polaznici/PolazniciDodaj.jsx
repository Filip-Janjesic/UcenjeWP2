import { Button, Col, Container, Form, Row } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import PolaznikService from '../../services/PolaznikService';
import { RoutesNames } from '../../constants';


export default function PolazniciDodaj() {
  const navigate = useNavigate();


  async function dodajPolaznik(Polaznik) {
    const odgovor = await PolaznikService.dodaj(Polaznik);
    if (odgovor.ok) {
      navigate(RoutesNames.POLAZNICI_PREGLED);
    } else {
      alert(odgovor.poruka.errors);
    }
  }

  function handleSubmit(e) {
    e.preventDefault();

    const podaci = new FormData(e.target);


    dodajPolaznik({
      ime: podaci.get('ime'),
      prezime: podaci.get('prezime'),
      oib: podaci.get('oib'),
      email: podaci.get('email'),
      brojugovora: podaci.get('brojugovora')
    });
  }

  return (
    <Container className='mt-4'>
      <Form onSubmit={handleSubmit}>
        <Form.Group className='mb-3' controlId='ime'>
          <Form.Label>Ime</Form.Label>
          <Form.Control
            type='text'
            name='ime'
            placeholder='Ime Polaznika'
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='prezime'>
          <Form.Label>Prezime</Form.Label>
          <Form.Control
            type='text'
            name='prezime'
            placeholder='Prezime Polaznika'
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='oib'>
          <Form.Label>OIB</Form.Label>
          <Form.Control
            type='text'
            name='oib'
            placeholder='OIB Polaznika'
            maxLength={11}
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='email'>
          <Form.Label>Email</Form.Label>
          <Form.Control
            type='email'
            name='email'
            placeholder='Email Polaznika'
            maxLength={255}
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='brojugovora'>
          <Form.Label>Broj ugovora</Form.Label>
          <Form.Control
            type='text'
            name='brojugovora'
            placeholder='Broj ugovora polaznika'
          />
        </Form.Group>

       

        <Row>
          <Col>
            <Link className='btn btn-danger gumb' to={RoutesNames.POLAZNICI_PREGLED}>
              Odustani
            </Link>
          </Col>
          <Col>
            <Button variant='primary' className='gumb' type='submit'>
              Dodaj Polaznika
            </Button>
          </Col>
        </Row>
      </Form>
    </Container>
  );
}
