import { Button, Col, Container, Form, Row } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import moment from "moment";


import Service from '../../services/GrupaService';
import SmjerService from '../../services/SmjerService';
import PredavacService from '../../services/PredavacService';
import { RoutesNames } from '../../constants';



export default function GrupeDodaj() {
  const navigate = useNavigate();

  const [smjerovi, setSmjerovi] = useState([]);
  const [smjerSifra, setSmjerSifra] = useState(0);

  const [predavaci, setPredavaci] = useState([]);
  const [predavacSifra, setPredavacSifra] = useState(0);

  async function dohvatiSmjerove(){
    await SmjerService.getSmjerovi().
      then((odgovor)=>{
        setSmjerovi(odgovor.data);
        setSmjerSifra(odgovor.data[0].sifra);
      });
  }

  async function dohvatiPredavaci(){
    await PredavacService.get().
      then((o)=>{
        setPredavaci(o.data);
        setPredavacSifra(o.data[0].sifra);
      });
  }

  async function ucitaj(){
    await dohvatiSmjerove();
    await dohvatiPredavaci();
  }

  useEffect(()=>{
    ucitaj();
  },[]);

  async function dodaj(e) {
    //console.log(e);

    const odgovor = await Service.dodaj(e);
    if (odgovor.ok) {
      navigate(RoutesNames.GRUPE_PREGLED);
    } else {
      alert(odgovor.poruka.errors);
    }
    
  }

  function handleSubmit(e) {
    e.preventDefault();

    const podaci = new FormData(e.target);

    //console.log(podaci.get('datum'));
    //console.log(podaci.get('vrijeme'));

    if(podaci.get('datum')=='' && podaci.get('vrijeme')!=''){
      alert('Ako postavljate vrijeme morate i datum');
      return;
    }
    let datumpocetka='';
    if(podaci.get('datum')!='' && podaci.get('vrijeme')==''){
      datumpocetka = podaci.get('datum') + 'T00:00:00.000Z';
    }else{
      datumpocetka = podaci.get('datum') + 'T' + podaci.get('vrijeme') + ':00.000Z';
    }



    
    //console.log(datumpocetka);

    dodaj({
      naziv: podaci.get('naziv'),
      datumpocetka: datumpocetka,
      smjerSifra: parseInt(smjerSifra),
      predavacSifra: parseInt(predavacSifra),
      maksimalnopolaznika: parseInt(podaci.get('maksimalnopolaznika'))
    });
  }

  function oibPredavaca(){
    for(let i=0;i<predavaci.length;i++){
      const e = predavaci[i];
      if(e.sifra==predavacSifra){
        return e.email;
      }
    }
    /*
    predavaci.forEach(e => {
      if(e.sifra==predavacSifra){
        console.log(e);
        return e.email;
      }
    });
    */
    //return 'Pero';
  }

  return (
    <Container className='mt-4'>
      <Form onSubmit={handleSubmit}>
        <Form.Group className='mb-3' controlId='naziv'>
          <Form.Label>Naziv</Form.Label>
          <Form.Control
            type='text'
            name='naziv'
            placeholder='Naziv grupe'
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='datum'>
          <Form.Label>Datum</Form.Label>
          <Form.Control
            type='date'
            name='datum'
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='vrijeme'>
          <Form.Label>Vrijeme</Form.Label>
          <Form.Control
            type='time'
            name='vrijeme'
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='smjer'>
          <Form.Label>Smjer</Form.Label>
          <Form.Select multiple={true}
          onChange={(e)=>{setSmjerSifra(e.target.value)}}
          >
          {smjerovi && smjerovi.map((s,index)=>(
            <option key={index} value={s.sifra}>
              {s.naziv}
            </option>
          ))}
          </Form.Select>
        </Form.Group>

        <Form.Group className='mb-3' controlId='predavac'>
          <Form.Label>Predavač</Form.Label>
          <Form.Select
          onChange={(e)=>{setPredavacSifra(e.target.value)}}
          >
          {predavaci && predavaci.map((e,index)=>(
            <option key={index} value={e.sifra}>
              {e.ime} {e.prezime}
            </option>
          ))}
          </Form.Select>
        </Form.Group>

        <Form.Group className='mb-3' controlId='predavacOib'>
          <Form.Label>{oibPredavaca()}</Form.Label>
        </Form.Group>

        <Form.Group className='mb-3' controlId='maksimalnopolaznika'>
          <Form.Label>Maksimalno polaznika</Form.Label>
          <Form.Control
            type='number'
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
              Dodaj Grupu
            </Button>
          </Col>
        </Row>
      </Form>
    </Container>
  );
}
