import { useEffect, useState } from "react";
import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import SmjerService from "../../services/SmjerService";
import { RoutesNames } from "../../constants";

export default function SmjeroviPromjeni(){

    const navigate = useNavigate();
    const routeParams = useParams();
    const [smjer,setSmjer] = useState({});

    async function dohvatiSmjer(){
        await SmjerService.getBySifra(routeParams.sifra)
        .then((res)=>{
            setSmjer(res.data)
        })
        .catch((e)=>{
            alert(e.poruka);
        });
    }

    useEffect(()=>{
        //console.log("useEffect")
        dohvatiSmjer();
    },[]);

    async function promjeniSmjer(smjer){
        const odgovor = await SmjerService.promjeniSmjer(routeParams.sifra,smjer);
        if(odgovor.ok){
          navigate(RoutesNames.SMJEROVI_PREGLED);
        }else{
          console.log(odgovor);
          alert(odgovor.poruka);
        }
    }

    function handleSubmit(e){
        e.preventDefault();
        const podaci = new FormData(e.target);

        const smjer = 
        {
            naziv: podaci.get('naziv'),
            trajanje: parseInt(podaci.get('trajanje')),
            cijena: parseFloat(podaci.get('cijena')),
            upisnina: parseFloat(podaci.get('upisnina')),
            verificiran: podaci.get('verificiran')=='on' ? true: false
          };

          //console.log(JSON.stringify(smjer));
          promjeniSmjer(smjer);
    }


    return (

        <Container>
           
           <Form onSubmit={handleSubmit}>

                <Form.Group controlId="naziv">
                    <Form.Label>Naziv</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={smjer.naziv}
                        name="naziv"
                    />
                </Form.Group>

                <Form.Group controlId="trajanje">
                    <Form.Label>Trajanje</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={smjer.trajanje}
                        name="trajanje"
                    />
                </Form.Group>

                <Form.Group controlId="cijena">
                    <Form.Label>Cijena</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={smjer.cijena}
                        name="cijena"
                    />
                </Form.Group>

                <Form.Group controlId="upisnina">
                    <Form.Label>Upisnina</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={smjer.upisnina}
                        name="upisnina"
                    />
                </Form.Group>

                <Form.Group controlId="verificiran">
                    <Form.Check 
                        label="Verificiran"
                        defaultChecked={smjer.verificiran}
                        name="verificiran"
                    />
                </Form.Group>

                <Row className="akcije">
                    <Col>
                        <Link 
                        className="btn btn-danger"
                        to={RoutesNames.SMJEROVI_PREGLED}>Odustani</Link>
                    </Col>
                    <Col>
                        <Button
                            variant="primary"
                            type="submit"
                        >
                            Promjeni smjer
                        </Button>
                    </Col>
                </Row>
                
           </Form>

        </Container>

    );

}