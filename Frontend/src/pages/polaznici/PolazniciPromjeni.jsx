import { useEffect, useRef, useState } from 'react';
import { Button, Col, Container, Form, Image, Row } from 'react-bootstrap';
import { useNavigate, useParams } from 'react-router-dom';
import Service from '../../services/PolaznikService';
import { App, RoutesNames } from '../../constants';
import { dohvatiPorukeAlert } from '../../services/httpService';
import InputText from '../../components/InputText';
import Akcije from '../../components/Akcije';
import Cropper from 'react-cropper';
import 'cropperjs/dist/cropper.css';
import nepoznato from '../../assets/nepoznato.png'; 
import useLoading from '../../hooks/useLoading';
import useError from '../../hooks/useError';

export default function PolazniciPromjeni() {
  const [polaznik, setPolaznik] = useState({});

  const [trenutnaSlika, setTrenutnaSlika] = useState('');
  const [slikaZaCrop, setSlikaZaCrop] = useState('');
  const [slikaZaServer, setSlikaZaServer] = useState('');
  const cropperRef = useRef(null);

  const routeParams = useParams();
  const navigate = useNavigate();
  const { prikaziError } = useError();
  const { showLoading, hideLoading } = useLoading();


  async function dohvatiPolaznik() {
    showLoading();
    const odgovor = await Service.getBySifra('Polaznik',routeParams.sifra);
    if(!odgovor.ok){
      hideLoading();
      prikaziError(odgovor.podaci);
      return;
    }
    setPolaznik(odgovor.podaci);
    //Date.now je zbog toga što se src na image komponenti cache-ira
    //pa kad promjenimo sliku url ostane isti i trenutna slika se ne updatea
    if(odgovor.podaci.slika!=null){
      setTrenutnaSlika(App.URL + odgovor.podaci.slika + `?${Date.now()}`);
    }else{
      setTrenutnaSlika(nepoznato);
    }
    hideLoading();
  }

  useEffect(() => {
    dohvatiPolaznik();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  async function promjeniPolaznik(polaznik) {
    showLoading();
    const odgovor = await Service.promjeni('Polaznik',routeParams.sifra, polaznik);
    if(odgovor.ok){
      hideLoading();
      navigate(RoutesNames.POLAZNICI_PREGLED);
      return;
    }
    alert(dohvatiPorukeAlert(odgovor.podaci));
    hideLoading();
  }

  function handleSubmit(e) {
    e.preventDefault();

    const podaci = new FormData(e.target);
    promjeniPolaznik({
      ime: podaci.get('ime'),
      prezime: podaci.get('prezime'),
      oib: podaci.get('oib'),
      email: podaci.get('email'),
      brojugovora: podaci.get('brojugovora'),
      slika: ''
    });
  }



  function onCrop() {
    setSlikaZaServer(cropperRef.current.cropper.getCroppedCanvas().toDataURL());
  }

  function onChangeImage(e) {
    e.preventDefault();

    let files;
    if (e.dataTransfer) {
      files = e.dataTransfer.files;
    } else if (e.target) {
      files = e.target.files;
    }
    const reader = new FileReader();
    reader.onload = () => {
      setSlikaZaCrop(reader.result);
    };
    try {
      reader.readAsDataURL(files[0]);
    } catch (error) {
      console.error(error);
    }
  }

  async function spremiSliku() {
    showLoading();
    const base64 = slikaZaServer;

    const odgovor = await Service.postaviSliku(routeParams.sifra, {Base64: base64.replace('data:image/png;base64,', '')});
    if(!odgovor.ok){
      hideLoading();
      prikaziError(odgovor.podaci);
    }
    //Date.now je zbog toga što se src na image komponenti cache-ira
    //pa kad promjenimo sliku url ostane isti i trenutna slika se ne updatea
    setTrenutnaSlika(slikaZaServer);
    hideLoading();
  }

  return (
    <Container className='mt-4'>
       <Row>
        <Col key='1' sm={12} lg={6} md={6}>
          <Form onSubmit={handleSubmit}>
            <InputText atribut='ime' vrijednost={polaznik.ime} />
            <InputText atribut='prezime' vrijednost={polaznik.prezime} />
            <InputText atribut='oib' vrijednost={polaznik.oib} />
            <InputText atribut='email' vrijednost={polaznik.email} />
            <InputText atribut='brojugovora' vrijednost={polaznik.brojugovora} />
            <Akcije odustani={RoutesNames.POLAZNICI_PREGLED} akcija='Promjeni polaznika' /> 
          </Form>
          <Row className='mb-4'>
              <Col key='1' sm={12} lg={6} md={12}>
                <p className='form-label'>Trenutna slika</p>
                <Image
                  //za lokalni development
                  //src={'https://edunovawp1.eu/' + trenutnaSlika}
                  src={trenutnaSlika}
                  className='slika'
                />
              </Col>
              <Col key='2' sm={12} lg={6} md={12}>
                {slikaZaServer && (
                  <>
                    <p className='form-label'>Nova slika</p>
                    <Image
                      src={slikaZaServer || slikaZaCrop}
                      className='slika'
                    />
                  </>
                )}
              </Col>
            </Row>
        </Col>
        <Col key='2' sm={12} lg={6} md={6}>
        <input className='mb-3' type='file' onChange={onChangeImage} />
              <Button disabled={!slikaZaServer} onClick={spremiSliku}>
                Spremi sliku
              </Button>

              <Cropper
                src={slikaZaCrop}
                style={{ height: 400, width: '100%' }}
                initialAspectRatio={1}
                guides={true}
                viewMode={1}
                minCropBoxWidth={50}
                minCropBoxHeight={50}
                cropBoxResizable={false}
                background={false}
                responsive={true}
                checkOrientation={false}
                cropstart={onCrop}
                cropend={onCrop}
                ref={cropperRef}
              />
        </Col>
      </Row>
      
    </Container>
  );
}
