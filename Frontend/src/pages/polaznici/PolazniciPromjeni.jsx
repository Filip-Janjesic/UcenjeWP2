import { useEffect, useState } from 'react';
import { Button, Col, Container, Form, Row } from 'react-bootstrap';
import { Link, useNavigate, useParams } from 'react-router-dom';
import PolaznikService from '../../services/PolaznikService';
import { RoutesNames } from '../../constants';

export default function PolazniciPromjeni() {
  const [polaznik, setPolaznik] = useState({});

  const routeParams = useParams();
  const navigate = useNavigate();


  async function dohvatiPolaznik() {

    await PolaznikService
      .getBySifra(routeParams.sifra)
      .then((response) => {
        console.log(response);
        setPolaznik(response.data);
      })
      .catch((err) => alert(err.poruka));

  }

  useEffect(() => {
    dohvatiPolaznik();
  }, []);

  async function promjeniPolaznik(polaznik) {
    const odgovor = await PolaznikService.promjeni(routeParams.sifra, polaznik);

    if (odgovor.ok) {
      navigate(RoutesNames.POLAZNICI_PREGLED);
    } else {
      alert(odgovor.poruka);

    }
  }

  function handleSubmit(e) {
    e.preventDefault();

    const podaci = new FormData(e.target);
    promjeniPolaznik({
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
            defaultValue={polaznik.ime}
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='prezime'>
          <Form.Label>Prezime</Form.Label>
          <Form.Control
            type='text'
            name='prezime'
            defaultValue={polaznik.prezime}
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='oib'>
          <Form.Label>OIB</Form.Label>
          <Form.Control
            type='text'
            name='oib'
            defaultValue={polaznik.oib}
            maxLength={11}
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='email'>
          <Form.Label>Email</Form.Label>
          <Form.Control
            type='email'
            name='email'
            defaultValue={polaznik.email}
            maxLength={255}
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='brojugovora'>
          <Form.Label>Broj ugovora</Form.Label>
          <Form.Control
            type='text'
            name='brojugovora'
            defaultValue={polaznik.brojugovora}
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
              Promjeni Polaznika
            </Button>
          </Col>
        </Row>
      </Form>
    </Container>
  );
}
