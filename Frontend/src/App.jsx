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
        </>
      </Routes>
    </>
  )
}

export default App
