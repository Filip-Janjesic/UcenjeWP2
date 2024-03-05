import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import PredavacService from "../../services/PredavacService";
import { IoIosAdd } from "react-icons/io";
import { FaEdit, FaTrash } from "react-icons/fa";
import { Link } from "react-router-dom";
import { RoutesNames } from "../../constants";
import { useNavigate } from "react-router-dom";

export default function Predavaci(){
    const [Predavaci,setPredavaci] = useState();
    let navigate = useNavigate(); 

    async function dohvatiPredavace(){
        await PredavacService.get()
        .then((res)=>{
            setPredavaci(res.data);
        })
        .catch((e)=>{
            alert(e);
        });
    }

    useEffect(()=>{
        dohvatiPredavace();
    },[]);



    async function obrisiPredavac(sifra) {
        const odgovor = await PredavacService.obrisi(sifra);
    
        if (odgovor.ok) {
            dohvatiPredavace();
        } else {
          alert(odgovor.poruka);
        }
      }

    return (

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

                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>

    );

}