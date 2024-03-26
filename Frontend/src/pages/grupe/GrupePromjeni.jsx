import { useState, useEffect, useRef } from 'react';
import { Button, Container, Form, Row, Col, Table } from 'react-bootstrap';
import { AsyncTypeahead } from 'react-bootstrap-typeahead';
import { Link, useNavigate, useParams } from 'react-router-dom';
import { FaTrash } from 'react-icons/fa';
import moment from 'moment';

import Service from '../../services/GrupaService';
import SmjerService from "../../services/SmjerService";
import PredavacService from "../../services/PredavacService";
import PolaznikService from "../../services/PolaznikService";
import { RoutesNames } from '../../constants';


export default function GrupePromjeni() {
  const navigate = useNavigate();

  const routeParams = useParams();

  const [grupa, setGrupa] = useState({});

  const [smjerovi, setSmjerovi] = useState([]);
  const [sifraSmjer, setSifraSmjer] = useState(0);

  const [predavaci, setPredavacii] = useState([]);
  const [sifraPredavac, setSifraPredavac] = useState(0);

  const [polaznici, setPolaznici] = useState([]);
  const [pronadeniPolaznici, setPronadeniPolaznici] = useState([]);

  const typeaheadRef = useRef(null);

  async function dohvatiInicijalnePodatke() {
    await dohvatiSmjerovi();
    await dohvatiPredavaci();
    await dohvatiGrupa();
    await dohvatiPolaznici();
  }

  async function dohvatiGrupa() {
    await Service
      .getBySifra(routeParams.sifra)
      .then((response) => {
        let grupa = response.data;
        grupa.vrijeme =moment.utc(grupa.datumpocetka).format('HH:mm');
        grupa.datum= moment.utc(grupa.datumpocetka).format('yyyy-MM-DD');
        delete grupa.datumpocetka;
        setGrupa(grupa);
        setSifraSmjer(grupa.smjerSifra);
        if(grupa.predavacSifra!=null){
          setSifraPredavac(grupa.predavacSifra);
        }
        
      
      })
      .catch((err) => console.log(err.poruka));
  }


  async function dohvatiPolaznici() {
    await Service
      .getPolaznici(routeParams.sifra)
      .then((response) => {
        setPolaznici(response.data);
        setSifraPolaznik(response.data[0].sifra);
      })
      .catch((err) => console.log(err.poruka));
  }

  async function dohvatiSmjerovi() {
    await SmjerService
      .getSmjerovi()
      .then((response) => {
        setSmjerovi(response.data);
        setSifraSmjer(response.data[0].sifra);
      })
      .catch((err) => console.log(err.poruka));
  }

  async function dohvatiPredavaci() {
    await PredavacService
      .get()
      .then((response) => {
        setPredavacii(response.data);
        setSifraPredavac(response.data[0].sifra);
      })
      .catch((err) => console.log(err.poruka));
  }

  async function traziPolaznik(uvjet) {
    await PolaznikService
      .traziPolaznik(uvjet)
      .then((response) => {
        setPronadeniPolaznici(response.data);
      })
      .catch((err) => prikaziError(err.poruka));
  }

  useEffect(() => {
    dohvatiInicijalnePodatke();
  }, []);

  async function promjeni(e) {
    const odgovor = await Service.promjeni(routeParams.sifra, e);
    if (odgovor.ok) {
      navigate(RoutesNames.GRUPE_PREGLED);
    } else {
      alert(odgovor.poruka.errors);
    }
  }


  async function obrisiPolaznika(grupa, polaznik) {
    const odgovor = await Service
      .obrisiPolaznika(grupa, polaznik)
      .then((res) => res)
      .catch((err) => console.log(err.poruka));

    if (odgovor?.ok) {
      await dohvatiPolaznici();
    }
  }

  async function dodajPolaznika(e) {
    //console.log(e[0]);
    const odgovor = await Service
      .dodajPolaznika(routeParams.sifra, e[0].sifra)
      .then((res) => res)
      .catch((err) => console.log(err.poruka));

    if (odgovor?.ok) {
      typeaheadRef.current.clear();
      await dohvatiPolaznici();
    }
  }

  function handleSubmit(e) {
    e.preventDefault();

    const podaci = new FormData(e.target);

    //console.log(podaci.get('datum'));
    //console.log(podaci.get('vrijeme'));
    const datum = moment.utc(podaci.get('datum') + ' ' + podaci.get('vrijeme'));
    //console.log(datum);

    promjeni({
      naziv: podaci.get('naziv'),
      datumpocetka: datum,
      smjerSifra: parseInt(sifraSmjer), 
      predavacSifra: parseInt(sifraPredavac),
      maksimalnopolaznika: parseInt(podaci.get('maksimalnopolaznika'))
    });
    
  }

  return (
    <Container className='mt-4'>
      <Form onSubmit={handleSubmit}>
      <Row>
          <Col key='1' sm={12} lg={6} md={6}>
        <Form.Group className='mb-3' controlId='naziv'>
          <Form.Label>Naziv</Form.Label>
          <Form.Control
            type='text'
            name='naziv'
            defaultValue={grupa.naziv}
            maxLength={255}
            required
          />
        </Form.Group>
        <Row>
          <Col key='1' sm={12} lg={6} md={6}>
              <Form.Group className='mb-3' controlId='datum'>
                <Form.Label>Datum</Form.Label>
                <Form.Control
                  type='date'
                  name='datum'
                  defaultValue={grupa.datum}
                />
              </Form.Group>
            </Col>
            <Col key='2' sm={12} lg={6} md={6}>
              <Form.Group className='mb-3' controlId='vrijeme'>
                <Form.Label>Vrijeme</Form.Label>
                <Form.Control
                  type='time'
                  name='vrijeme'
                  defaultValue={grupa.vrijeme}
                />
              </Form.Group>
            </Col>
            </Row>
        

        
 
        <Form.Group className='mb-3' controlId='smjer'>
          <Form.Label>Smjer</Form.Label>
          <Form.Select
             value={sifraSmjer}
             onChange={(e) => {
               setSifraSmjer(e.target.value);
             }}
          >
            {smjerovi &&
              smjerovi.map((smjer, index) => (
                <option key={index} value={smjer.sifra}>
                  {smjer.naziv}
                </option>
              ))}
          </Form.Select>
        </Form.Group>


        <Form.Group className='mb-3' controlId='predavac'>
          <Form.Label>Predavač</Form.Label>
          <Form.Select
            value={sifraPredavac}
            onChange={(e) => {
              setSifraPredavac(e.target.value);
            }}
          >
            {predavaci &&
              predavaci.map((predavac, index) => (
                <option key={index} value={predavac.sifra}>
                  {predavac.ime} {predavac.prezime}
                </option>
              ))}
          </Form.Select>
        </Form.Group>

        <Form.Group className='mb-3' controlId='maksimalnopolaznika'>
          <Form.Label>Maksimalno polaznika</Form.Label>
          <Form.Control
            type='text'
            name='maksimalnopolaznika'
            placeholder='20'
          />
        </Form.Group>
       

        <Row>
          <Col>
            <Link className='btn btn-danger gumb' to={RoutesNames.GRUPE_PREGLED}>
              Odustani
            </Link>
          </Col>
          <Col>
            <Button variant='primary' className='gumb' type='submit'>
              Promjeni Grupu
            </Button>
          </Col>
        </Row>
        </Col>
          <Col key='2' sm={12} lg={6} md={6}>
          <Form.Group className='mb-3' controlId='uvjet'>
              <Form.Label>Traži polaznika</Form.Label>
              <AsyncTypeahead
                className='autocomplete'
                id='uvjet'
                emptyLabel='Nema rezultata'
                searchText='Tražim...'
                labelKey={(polaznik) => `${polaznik.prezime} ${polaznik.ime}`}
                minLength={3}
                options={pronadeniPolaznici}
                onSearch={traziPolaznik}
                placeholder='dio imena ili prezimena'
                renderMenuItemChildren={(polaznik) => (
                  <>
                    <span>
                      {polaznik.prezime} {polaznik.ime}
                    </span>
                  </>
                )}
                onChange={dodajPolaznika}
                ref={typeaheadRef}
              />
            </Form.Group>
            <Table striped bordered hover>
              <thead>
                <tr>
                  <th>Polaznik</th>
                  <th>Akcija</th>
                </tr>
              </thead>
              <tbody>
                {polaznici &&
                  polaznici.map((polaznik, index) => (
                    <tr key={index}>
                      <td>
                        {polaznik.ime} {polaznik.prezime}
                      </td>
                      <td>
                        <Button
                          variant='danger'
                          onClick={() =>
                            obrisiPolaznika(routeParams.sifra, polaznik.sifra)
                          }
                        >
                          <FaTrash />
                        </Button>
                      </td>
                    </tr>
                  ))}
              </tbody>
            </Table>
          </Col>
        </Row>
      </Form>
    </Container>
  );
}
