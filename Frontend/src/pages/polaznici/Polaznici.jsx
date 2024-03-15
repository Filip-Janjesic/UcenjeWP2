import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import PolaznikService from "../../services/PolaznikService";
import { IoIosAdd } from "react-icons/io";
import { FaEdit, FaTrash } from "react-icons/fa";
import { Link } from "react-router-dom";
import { RoutesNames } from "../../constants";
import { useNavigate } from "react-router-dom";

export default function Polaznici(){
    const [polaznici,setPolaznici] = useState();
    let navigate = useNavigate(); 

    async function dohvatiPolaznike(){
        await PolaznikService.get()
        .then((res)=>{
            setPolaznici(res.data);
        })
        .catch((e)=>{
            alert(e);
        });
    }

    useEffect(()=>{
        dohvatiPolaznike();
    },[]);



    async function obrisiPolaznik(sifra) {
        const odgovor = await PolaznikService.obrisi(sifra);
    
        if (odgovor.ok) {
            dohvatiPolaznike();
        } else {
          alert(odgovor.poruka);
        }
      }

    return (

        <Container>
            <Link to={RoutesNames.POLAZNICI_NOVI} className="btn btn-success gumb">
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
                    {polaznici && polaznici.map((entitet,index)=>(
                        <tr key={index}>
                            <td>{entitet.ime}</td>
                            <td>{entitet.prezime}</td>
                            <td>{entitet.oib}</td>
                            <td>{entitet.email}</td>
                            <td>{entitet.brojugovora}</td>
                            <td className="sredina">
                                    <Button
                                        variant='primary'
                                        onClick={()=>{navigate(`/polaznici/${entitet.sifra}`)}}
                                    >
                                        <FaEdit 
                                    size={25}
                                    />
                                    </Button>
                               
                                
                                    &nbsp;&nbsp;&nbsp;
                                    <Button
                                        variant='danger'
                                        onClick={() => obrisiPolaznik(entitet.sifra)}
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