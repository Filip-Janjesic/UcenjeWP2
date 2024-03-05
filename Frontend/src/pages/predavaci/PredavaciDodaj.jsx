import { Button, Col, Container, Form, Row } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import PredavacService from '../../services/PredavacService';
import { RoutesNames } from '../../constants';


export default function PredavaciDodaj() {
  const navigate = useNavigate();


  async function dodajPredavac(Predavac) {
    const odgovor = await PredavacService.dodaj(Predavac);
    if (odgovor.ok) {
      navigate(RoutesNames.PREDAVACI_PREGLED);
    } else {
      alert(odgovor.poruka.errors);
    }
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
    <Container className='mt-4'>
      <Form onSubmit={handleSubmit}>
        <Form.Group className='mb-3' controlId='ime'>
          <Form.Label>Ime</Form.Label>
          <Form.Control
            type='text'
            name='ime'
            placeholder='Ime Predavaca'
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='prezime'>
          <Form.Label>Prezime</Form.Label>
          <Form.Control
            type='text'
            name='prezime'
            placeholder='Prezime Predavaca'
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='oib'>
          <Form.Label>OIB</Form.Label>
          <Form.Control
            type='text'
            name='oib'
            placeholder='OIB Predavaca'
            maxLength={11}
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='email'>
          <Form.Label>Email</Form.Label>
          <Form.Control
            type='email'
            name='email'
            placeholder='Email Predavaca'
            maxLength={255}
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='iban'>
          <Form.Label>IBAN</Form.Label>
          <Form.Control
            type='text'
            name='iban'
            placeholder='IBAN Predavaca'
          />
        </Form.Group>

       

        <Row>
          <Col>
            <Link className='btn btn-danger gumb' to={RoutesNames.PREDAVACI_PREGLED}>
              Odustani
            </Link>
          </Col>
          <Col>
            <Button variant='primary' className='gumb' type='submit'>
              Dodaj Predavača
            </Button>
          </Col>
        </Row>
      </Form>
    </Container>
  );
}
