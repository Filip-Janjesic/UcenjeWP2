import { useEffect, useState } from "react";
import { Button, Container, Form, Modal, Table } from "react-bootstrap";
import Service from "../../services/PredavacService";
import { IoIosAdd } from "react-icons/io";
import { FaDownload, FaEdit, FaTrash, FaUpload } from "react-icons/fa";
import { Link } from "react-router-dom";
import { App, RoutesNames } from "../../constants";
import { useNavigate } from "react-router-dom";
import useError from "../../hooks/useError";

export default function Predavaci(){
    const [Predavaci,setPredavaci] = useState();
    let navigate = useNavigate(); 
    const { prikaziError } = useError();
    const [prikaziModal, setPrikaziModal] = useState(false);
    const [odabraniPredavac,setOdabraniPredavac] = useState({});

    async function dohvatiPredavace(){
        const odgovor = await Service.get('Predavac');
        if(!odgovor.ok){
            prikaziError(odgovor.podaci);
            return;
        }
        setPredavaci(odgovor.podaci);
    }

    async function obrisiPredavac(sifra) {
        const odgovor = await Service.obrisi('Predavac',sifra);
        prikaziError(odgovor.podaci);
        if (odgovor.ok){
            dohvatiPredavace();
        }
    }

    useEffect(()=>{
        dohvatiPredavace();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    },[]);

    function postaviDatotekuModal(predavac){
        setOdabraniPredavac(predavac);
        setPrikaziModal(true);
    }

    function zatvoriModal(){
        setPrikaziModal(false);
    }

    async function postaviDatoteku(e){
        if (e.currentTarget.files) {
            const formData = new FormData();
            formData.append('datoteka', e.currentTarget.files[0]);
            const config = {
            headers: {
                'content-type': 'multipart/form-data',
            },
            };
            const odgovor = await Service.postaviDatoteku(odabraniPredavac.sifra,formData,config);
            alert(dohvatiPorukeAlert(odgovor.podaci));
            if (odgovor.ok){
                dohvatiPredavace();
                setPrikaziModal(false);
            }
        }
    }


    return (
        <>
        <Container>
            <Link to={RoutesNames.PREDAVACI_NOVI} className="btn btn-success gumb">
                <IoIosAdd
                size={25}
                /> Dodaj
            </Link>
            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>Ime</th>
                        <th>Prezime</th>
                        <th>OIB</th>
                        <th>Email</th>
                        <th>IBAN</th>
                        <th>Akcija</th>
                    </tr>
                </thead>
                <tbody>
                    {Predavaci && Predavaci.map((predavac,index)=>(
                        <tr key={index}>
                            <td>{predavac.ime}</td>
                            <td>{predavac.prezime}</td>
                            <td>{predavac.oib}</td>
                            <td>{predavac.email}</td>
                            <td>{predavac.iban}</td>
                            <td className="sredina">
                                    <Button
                                        variant='primary'
                                        onClick={()=>{navigate(`/predavaci/${predavac.sifra}`)}}
                                    >
                                        <FaEdit 
                                    size={25}
                                    />
                                    </Button>
                               
                                
                                    &nbsp;&nbsp;&nbsp;
                                    <Button
                                        variant='danger'
                                        onClick={() => obrisiPredavac(predavac.sifra)}
                                    >
                                        <FaTrash
                                        size={25}/>
                                    </Button>

                                   

                                        {predavac.datoteka!=null ? 
                                        <>
                                        &nbsp;&nbsp;&nbsp;
                                        <a target="_blank" href={App.URL + predavac.datoteka}>
                                            <FaDownload
                                            size={25}/>
                                        </a>
                                        </>
                                        
                                    : ''
                                    }
                                    &nbsp;&nbsp;&nbsp;
                                        <Button
                                            onClick={() => postaviDatotekuModal(predavac)}
                                        >
                                            <FaUpload
                                            size={25}/>
                                        </Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
            <Modal show={prikaziModal} onHide={zatvoriModal}>
                <Modal.Header closeButton>
                <Modal.Title>Postavljanje datoteke na <br /> {odabraniPredavac.prezime}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group>
                            <Form.Control type="file" size="lg" 
                            name='datoteka'
                            id='datoteka'
                            onChange={postaviDatoteku}
                            />
                        </Form.Group>
                        <hr />
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