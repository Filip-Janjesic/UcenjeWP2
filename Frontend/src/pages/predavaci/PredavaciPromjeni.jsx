import { useEffect, useState } from 'react';
import { Button, Col, Container, Form, Row } from 'react-bootstrap';
import { Link, useNavigate, useParams } from 'react-router-dom';
import PredavacService from '../../services/PredavacService';
import { RoutesNames } from '../../constants';

export default function PredavaciPromjeni() {
  const [predavac, setPredavac] = useState({});

  const routeParams = useParams();
  const navigate = useNavigate();


  async function dohvatiPredavac() {

    await PredavacService
      .getBySifra(routeParams.sifra)
      .then((response) => {
        console.log(response);
        setPredavac(response.data);
      })
      .catch((err) => alert(err.poruka));

  }

  useEffect(() => {
    dohvatiPredavac();
  }, []);

  async function promjeniPredavac(predavac) {
    const odgovor = await PredavacService.promjeni(routeParams.sifra, predavac);

    if (odgovor.ok) {
      navigate(RoutesNames.PREDAVACI_PREGLED);
    } else {
      alert(odgovor.poruka);

    }
  }

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
    <Container className='mt-4'>
      <Form onSubmit={handleSubmit}>

      <Form.Group className='mb-3' controlId='ime'>
          <Form.Label>Ime</Form.Label>
          <Form.Control
            type='text'
            name='ime'
            defaultValue={predavac.ime}
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='prezime'>
          <Form.Label>Prezime</Form.Label>
          <Form.Control
            type='text'
            name='prezime'
            defaultValue={predavac.prezime}
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='oib'>
          <Form.Label>OIB</Form.Label>
          <Form.Control
            type='text'
            name='oib'
            defaultValue={predavac.oib}
            maxLength={11}
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='email'>
          <Form.Label>Email</Form.Label>
          <Form.Control
            type='email'
            name='email'
            defaultValue={predavac.email}
            maxLength={255}
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='iban'>
          <Form.Label>IBAN</Form.Label>
          <Form.Control
            type='text'
            name='iban'
            defaultValue={predavac.iban}
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
              Promjeni predavača
            </Button>
          </Col>
        </Row>
      </Form>
    </Container>
  );
}
