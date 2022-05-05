import { Routes,Route,Router } from "react-router-dom"
import ClientAddress from "./Components/Screens/ClientAddressPage";
import ClientLends from "./Components/Screens/ClientsLendPage";
import LendPage from "./Components/Screens/LendPage";
import ComicBookPage from "./Components/Screens/ComicBookPage";
import AltHomePage from "./Components/Screens/AlternativeHomePage"

function App() {
  return (
    <Routes>
            <Route path="/" exact element={<AltHomePage/>}></Route>
            <Route path="/Client/:id/Address" exact element={<ClientAddress/>}/>
            <Route path="/Client/:id/Lends" exact  element={<ClientLends/>}/>
            <Route path="Lends/:id" exact element={<LendPage/>}></Route>
            <Route path="/ComicBook/:id" exact element={<ComicBookPage/>}></Route>
    </Routes>
  );
}

export default App;