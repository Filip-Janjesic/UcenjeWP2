import { useState, useEffect, useRef } from 'react';
import { Button, Container, Form, Row, Col, Table } from 'react-bootstrap';
import { AsyncTypeahead } from 'react-bootstrap-typeahead';
import { useNavigate, useParams } from 'react-router-dom';
import { FaTrash } from 'react-icons/fa';
import moment from 'moment';

import Service from '../../services/GrupaService';
import PolaznikService from "../../services/PolaznikService";
import { RoutesNames } from '../../constants';
import useError from '../../hooks/useError';
import InputText from '../../components/InputText';
import Akcije from '../../components/Akcije';
import useLoading from '../../hooks/useLoading';


export default function GrupePromjeni() {
  const navigate = useNavigate();
  const routeParams = useParams();
  const [grupa, setGrupa] = useState({});

  const [smjerovi, setSmjerovi] = useState([]);
  const [sifraSmjer, setSifraSmjer] = useState(0);

  const [predavaci, setPredavaci] = useState([]);
  const [sifraPredavac, setSifraPredavac] = useState(0);

  const [polaznici, setPolaznici] = useState([]);
  const [pronadeniPolaznici, setPronadeniPolaznici] = useState([]);

  const [searchName, setSearchName] = useState('');

  const typeaheadRef = useRef(null);

  const { prikaziError } = useError();
  const { showLoading, hideLoading } = useLoading();



  async function dohvatiGrupa() {
    const odgovor = await Service.getBySifra('Grupa',routeParams.sifra);
    if(!odgovor.ok){
      prikaziError(odgovor.podaci);
      return;
    }
    let grupa = odgovor.podaci;
    grupa.vrijeme =moment.utc(grupa.datumpocetka).format('HH:mm');
    grupa.datum= moment.utc(grupa.datumpocetka).format('yyyy-MM-DD');
    delete grupa.datumpocetka;
    setGrupa(grupa);
    setSifraSmjer(grupa.smjerSifra);
    if(grupa.predavacSifra!=null){
      setSifraPredavac(grupa.predavacSifra);
    }       
  }

  async function dohvatiPolaznici() {
    const odgovor = await Service.getPolaznici('Grupa',routeParams.sifra);
    if(!odgovor.ok){
      prikaziError(odgovor.podaci);
      return;
    }
    setPolaznici(odgovor.podaci);
  }

  async function dohvatiSmjerovi() {
    const odgovor =  await Service.get('Smjer');
    if(!odgovor.ok){
      prikaziError(odgovor.podaci);
      return;
    }
    setSmjerovi(odgovor.podaci);
    setSifraSmjer(odgovor.podaci[0].sifra);
      
  }

  async function dohvatiPredavaci() {
    const odgovor =  await Service.get('Predavac');
    if(!odgovor.ok){
      prikaziError(odgovor.podaci);
      return;
    }
    setPredavaci(odgovor.podaci);
    setSifraPredavac(odgovor.podaci[0].sifra);
  }

  async function traziPolaznik(uvjet) {
    const odgovor =  await PolaznikService.traziPolaznik('Polaznik',uvjet);
    if(!odgovor.ok){
      prikaziError(odgovor.podaci);
      return;
    }
    setPronadeniPolaznici(odgovor.podaci);
    setSearchName(uvjet);
  }

  async function dohvatiInicijalnePodatke() {
    showLoading();
    await dohvatiSmjerovi();
    await dohvatiPredavaci();
    await dohvatiGrupa();
    await dohvatiPolaznici();
    hideLoading();
  }

  useEffect(() => {
    dohvatiInicijalnePodatke();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  async function promjeni(e) {
    const odgovor = await Service.promjeni('Grupa',routeParams.sifra, e);
    if(odgovor.ok){
      navigate(RoutesNames.GRUPE_PREGLED);
      return;
    }
    prikaziError(odgovor.podaci);
  }


  async function obrisiPolaznika(grupa, polaznik) {
    const odgovor = await Service.obrisiPolaznika('Grupa',grupa, polaznik);
    if(odgovor.ok){
      await dohvatiPolaznici();
      return;
    }
    prikaziError(odgovor.podaci);
  }

  async function dodajPolaznika(e) {
    showLoading();
    const odgovor = await Service.dodajPolaznika('Grupa',routeParams.sifra, e[0].sifra);
    if(odgovor.ok){
      await dohvatiPolaznici();
      hideLoading();
      return;
    }
    hideLoading();
    prikaziError(odgovor.podaci);
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

  async function dodajRucnoPolaznik(Polaznik) {
    showLoading();
    const odgovor = await PolaznikService.dodaj('Polaznik',Polaznik);
    if (odgovor.ok) {
      const odgovor2 = await Service.dodajPolaznika('Grupa',routeParams.sifra, odgovor.podaci.sifra);
      if (odgovor2?.ok) {
        typeaheadRef.current.clear();
        await dohvatiPolaznici();
        hideLoading();
        return;
      }
      hideLoading();
      prikaziError(odgovor2.podaci);
      return;
    }
    hideLoading();
    prikaziError(odgovor.podaci);
      
  }

  function dodajRucnoPolaznika(){
    let niz = searchName.split(' ');
    if(niz.length<2){
      prikaziError([{svojstvo:'',poruka:'Obavezno ime i prezime'}]);
      return;
    }

    dodajRucnoPolaznik({
      ime: niz[0],
      prezime: niz[1],
      oib: '',
      email: 'pero@pero.com',
      brojugovora: ''
    });

    
  }

  return (
    <Container className='mt-4'>
      <Form onSubmit={handleSubmit}>
      <Row>
          <Col key='1' sm={12} lg={6} md={6}>
            <InputText atribut='naziv' vrijednost={grupa.naziv} />
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
                }}>
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
                }}>
                {predavaci &&
                  predavaci.map((predavac, index) => (
                    <option key={index} value={predavac.sifra}>
                      {predavac.ime} {predavac.prezime}
                    </option>
                  ))}
              </Form.Select>
            </Form.Group>
            <InputText atribut='maksimalnopolaznika' vrijednost={grupa.maksimalnopolaznika} />
            <Akcije odustani={RoutesNames.GRUPE_PREGLED} akcija='Promjeni grupu' /> 
          </Col>
          <Col key='2' sm={12} lg={6} md={6}>
            <Form.Group className='mb-3' controlId='uvjet'>
              <Row>
                <Col key='1' sm={12} lg={10} md={10}>
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
                  </Col>
                  <Col key='2' sm={12} lg={2} md={2}>
                    <Button onClick={dodajRucnoPolaznika}>
                      Dodaj
                    </Button>
                </Col>
              </Row>
            </Form.Group>
              <Table striped bordered hover>
                <thead>
                  <tr>
                    <th>Polaznici na grupi</th>
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
                              &nbsp;
                          <Button
                  
                                          onClick={()=>{navigate(`/polaznici/${polaznik.sifra}`)}}
                                      >Detalji</Button>
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
