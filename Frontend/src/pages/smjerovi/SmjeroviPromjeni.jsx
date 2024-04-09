import { useEffect, useRef, useState } from "react";
import { Button, Col, Container, Form, Modal, Row, Table } from "react-bootstrap";
import { useNavigate, useParams } from "react-router-dom";
import Service from "../../services/SmjerService";
import OznakaService from "../../services/OznakaService";
import { RoutesNames } from "../../constants";
import useError from "../../hooks/useError";
import InputText from "../../components/InputText";
import InputCheckbox from "../../components/InputCheckbox";
import Akcije from "../../components/Akcije";
import { FaTrash } from "react-icons/fa";
import { AsyncTypeahead } from "react-bootstrap-typeahead";
import useLoading from "../../hooks/useLoading";

export default function SmjeroviPromjeni(){

    const navigate = useNavigate();
    const routeParams = useParams();
    const [smjer,setSmjer] = useState({});
    const { prikaziError } = useError();
    const [oznake, setOznake] = useState([]);
    const [pronadeneOznake, setPronadeneOznake] = useState([]);
    const typeaheadRef = useRef(null);
    const [prikaziModal, setPrikaziModal] = useState(false);
    const [odabranaOznaka, setOdabranaOznaka] = useState(false);
    const { showLoading, hideLoading } = useLoading();

    async function dohvatiSmjer(){
      showLoading();
        const odgovor = await Service.getBySifra('Smjer',routeParams.sifra)
        if(!odgovor.ok){
            prikaziError(odgovor.podaci);
            navigate(RoutesNames.SMJEROVI_PREGLED);
            return;
        }
        setSmjer(odgovor.podaci);
        setPrikaziModal(false);
        hideLoading();
    }

    async function traziOznaka(uvjet) {
        const odgovor =  await OznakaService.traziOznaka('Oznaka',uvjet);
        if(!odgovor.ok){
          prikaziError(odgovor.podaci);
          return;
        }
        setPronadeneOznake(odgovor.podaci);
      }

    async function dohvatiOznake() {
        const odgovor = await Service.getOznake(routeParams.sifra);
        if(!odgovor.ok){
          prikaziError(odgovor.podaci);
          return;
        }
        setOznake(odgovor.podaci);
      }

    useEffect(()=>{
        dohvatiSmjer();
        dohvatiOznake();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    },[]);

    async function promjeniSmjer(smjer){
      showLoading();
        const odgovor = await Service.promjeni('Smjer',routeParams.sifra,smjer);
        if(odgovor.ok){
          navigate(RoutesNames.SMJEROVI_PREGLED);
          hideLoading();
          return;
        }
        prikaziError(odgovor.podaci);
        hideLoading();
    }

    async function obrisiOznaku(sifra) {
      showLoading(); 
        const odgovor = await Service.obrisiOznaku(sifra);
        if(odgovor.ok){
          await dohvatiOznake();
          hideLoading();
          return;
        }
        prikaziError(odgovor.podaci);
        hideLoading();
      }

      async function dodajOznakuModal(e) {
        setOdabranaOznaka(e[0]);
        setPrikaziModal(true);
      }

      async function dodajOznaku() {
        showLoading();
        const odgovor = await Service.dodajOznaku({
          smjerSifra: routeParams.sifra,
          oznakaSifra: odabranaOznaka.sifra,
          napomena: document.getElementById('napomena').value
        });
        if(odgovor.ok){
          setPrikaziModal(false);
          await dohvatiOznake();
          typeaheadRef.current.clear();
          hideLoading();
          return;
        }
        prikaziError(odgovor.podaci);
        hideLoading();
      }

    function handleSubmit(e){
        e.preventDefault();
        const podaci = new FormData(e.target);
        promjeniSmjer({
            naziv: podaci.get('naziv'),
            trajanje: parseInt(podaci.get('trajanje')),
            cijena: parseFloat(podaci.get('cijena')),
            upisnina: parseFloat(podaci.get('upisnina')),
            verificiran: podaci.get('verificiran')=='on' ? true: false
        });
    }

    function zatvoriModal(){
        setPrikaziModal(false);
    }


    return (
        <>

        <Container>
           <Form onSubmit={handleSubmit}>
            <Row>
                <Col key='1' sm={12} lg={6} md={6}>
                    <InputText atribut='naziv' vrijednost={smjer.naziv} />
                    <InputText atribut='trajanje' vrijednost={smjer.trajanje} />
                    <InputText atribut='cijena' vrijednost={smjer.cijena} />
                    <InputText atribut='upisnina' vrijednost={smjer.upisnina} />
                    <InputCheckbox atribut='verificiran' vrijednost={smjer.verificiran} />
                    <Akcije odustani={RoutesNames.SMJEROVI_PREGLED} akcija='Promjeni smjer' />
                </Col>
                <Col key='2' sm={12} lg={6} md={6}>
                <Form.Label>Traži oznaku</Form.Label>
                  <AsyncTypeahead
                  className='autocomplete'
                  id='uvjet'
                  emptyLabel='Nema rezultata'
                  searchText='Tražim...'
                  labelKey={(o) => `${o.naziv}`}
                  minLength={3}
                  options={pronadeneOznake}
                  onSearch={traziOznaka}
                  placeholder='dio naziva oznake'
                  renderMenuItemChildren={(o) => (
                    <>
                      <span>
                        {o.naziv}
                      </span>
                    </>
                  )}
                  onChange={dodajOznakuModal}
                  ref={typeaheadRef}
                  />

                        <Table striped bordered hover>
                        <thead>
                        <tr>
                            <th>Oznake na smjeru</th>
                            <th>Akcija</th>
                        </tr>
                        </thead>
                        <tbody>
                        {oznake &&
                            oznake.map((o, index) => (
                            <tr key={index}>
                                <td>
                                {o.oznaka}
                                <hr />
                                {o.napomena}
                                </td>
                                <td>
                                <Button
                                    variant='danger'
                                    onClick={() =>
                                    obrisiOznaku(o.sifra)
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

        <Modal show={prikaziModal} onHide={zatvoriModal}>
        <Modal.Header closeButton>
        <Modal.Title>Dodavanje nove oznake na smjer <br /> {smjer.naziv}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            Oznaka: {odabranaOznaka.naziv}
            <Form>
                <Form.Group>
                    <Form.Label>Napomena</Form.Label>
                    <Form.Control
                    autoFocus
                    id='napomena'
                    as='textarea' rows={3}
                    name='napomena'
                    />
                </Form.Group>
                <hr />
                <Button variant='primary' onClick={dodajOznaku}>
                    Dodaj
                </Button>
            </Form>
        </Modal.Body>
        <Modal.Footer>
        <Button variant='secondary' onClick={zatvoriModal}>
            Zatvori
        </Button>
        </Modal.Footer>
        </Modal>

        </>

    );

}