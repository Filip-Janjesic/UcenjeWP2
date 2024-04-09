import { Container, Form } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import Service from "../../services/SmjerService";
import useError from '../../hooks/useError';
import InputText from "../../components/InputText";
import InputCheckbox from "../../components/InputCheckbox";
import Akcije from "../../components/Akcije";
import useLoading from "../../hooks/useLoading";

export default function SmjeroviDodaj(){
    const navigate = useNavigate();
    const { prikaziError } = useError();
    const { showLoading, hideLoading } = useLoading();

    async function dodajSmjer(smjer){
        showLoading();
        const odgovor = await Service.dodaj('Smjer',smjer);
        if(odgovor.ok){
          navigate(RoutesNames.SMJEROVI_PREGLED);
          return
        }
        prikaziError(odgovor.podaci);
        hideLoading();
    }

    function handleSubmit(e){
        e.preventDefault();
        const podaci = new FormData(e.target);
        dodajSmjer({
            naziv: podaci.get('naziv'),
            trajanje: parseInt(podaci.get('trajanje')),
            cijena: parseFloat(podaci.get('cijena')),
            upisnina: parseFloat(podaci.get('upisnina')),
            verificiran: podaci.get('verificiran')=='on' ? true: false
        });
    }

    return (

        <Container>
           <Form onSubmit={handleSubmit}>
                <InputText atribut='naziv' vrijednost='' />
                <InputText atribut='trajanje' vrijednost='' />
                <InputText atribut='cijena' vrijednost='' />
                <InputText atribut='upisnina' vrijednost='' />
                <InputCheckbox atribut='verificiran' vrijednost={false} />
                <Akcije odustani={RoutesNames.SMJEROVI_PREGLED} akcija='Dodaj smjer' />
           </Form>
        </Container>

    );

}