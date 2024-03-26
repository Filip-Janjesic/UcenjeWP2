import { Route, Routes } from "react-router-dom"
import Pocetna from "./pages/Pocetna"
import { RoutesNames } from "./constants"
import NavBar from "./components/NavBar"
import Smjerovi from "./pages/smjerovi/Smjerovi"


import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css';
import SmjeroviDodaj from "./pages/smjerovi/SmjeroviDodaj"
import SmjeroviPromjeni from "./pages/smjerovi/SmjeroviPromjeni"

import Predavaci from "./pages/predavaci/Predavaci"
import PredavaciDodaj from "./pages/predavaci/PredavaciDodaj"
import PredavaciPromjeni from "./pages/predavaci/PredavaciPromjeni"

import Polaznici from "./pages/polaznici/Polaznici"
import PolazniciDodaj from "./pages/polaznici/PolazniciDodaj"
import PolazniciPromjeni from "./pages/polaznici/PolazniciPromjeni"

import Grupe from "./pages/grupe/Grupe"
import GrupeDodaj from "./pages/grupe/GrupeDodaj"
import GrupePromjeni from "./pages/grupe/GrupePromjeni"

function App() {
  return (
    <>
      <NavBar />
      <Routes>
        <>
          <Route path={RoutesNames.HOME} element={<Pocetna />} />

          
          <Route path={RoutesNames.SMJEROVI_PREGLED} element={<Smjerovi />} />
          <Route path={RoutesNames.SMJEROVI_NOVI} element={<SmjeroviDodaj />} />
          <Route path={RoutesNames.SMJEROVI_PROMJENI} element={<SmjeroviPromjeni />} />


          <Route path={RoutesNames.PREDAVACI_PREGLED} element={<Predavaci />} />
          <Route path={RoutesNames.PREDAVACI_NOVI} element={<PredavaciDodaj />} />
          <Route path={RoutesNames.PREDAVACI_PROMJENI} element={<PredavaciPromjeni />} />

          <Route path={RoutesNames.POLAZNICI_PREGLED} element={<Polaznici />} />
          <Route path={RoutesNames.POLAZNICI_NOVI} element={<PolazniciDodaj />} />
          <Route path={RoutesNames.POLAZNICI_PROMJENI} element={<PolazniciPromjeni />} />

          <Route path={RoutesNames.GRUPE_PREGLED} element={<Grupe />} />
          <Route path={RoutesNames.GRUPE_NOVI} element={<GrupeDodaj />} />
          <Route path={RoutesNames.GRUPE_PROMJENI} element={<GrupePromjeni />} />
        </>
      </Routes>
    </>
  )
}

export default App
